using MediatR;
using Shoppy.Application.Features.ProductRatings.Request.Command;
using Shoppy.Application.Mappers;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Application.Features.ProductRatings.Handler.Command;

public class CreateCommandHandler : IRequestHandler<CreateRatingCommand>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public CreateCommandHandler(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task Handle(CreateRatingCommand request, CancellationToken cancellationToken)
    {
        //get order item 

        var orderItem = await _unitOfWork.OrderItemRepository.GetByIdAsync(request.OrderItemId, cancellationToken);
        if (orderItem == null)
            throw new NotFoundException("Order detail not found.");
        
        //check authorize
        if (orderItem.Order.UserId != _currentUser.UserId)
            throw new ForbiddenException("Access denied");

        var ratingEntity = RatingMapper.RatingDtoToEntity(request);

        //Add rating 
        if (orderItem.IsReviewed)
            throw new BadRequestException("Order has been reviewed");

        orderItem.IsReviewed = true;
        orderItem.ProductRating = ratingEntity;

        await _unitOfWork.SaveChangeAsync();

        //Update product avg rate

        var productOrderDetails = await _unitOfWork.OrderItemRepository.GetProductOrderDetailAsync(orderItem.ProductId);

        var totalRate = productOrderDetails.Count + 1;

        var totalRateValue = productOrderDetails.Sum(o => o.ProductRating.RateValue) + ratingEntity.RateValue;

        decimal? avgRate = totalRate != 0 ? (decimal)totalRateValue / totalRate : null;

        await _unitOfWork.ProductRepository.UpdateAvgRateAsync(orderItem.ProductId, avgRate);
    }
}