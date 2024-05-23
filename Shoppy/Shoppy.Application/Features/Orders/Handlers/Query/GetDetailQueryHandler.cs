using MediatR;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Application.Features.Orders.Handlers.Query;

public class GetDetailQueryHandler : IRequestHandler<GetOrderDetailQuery, OrderDto>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetDetailQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<OrderDto> Handle(GetOrderDetailQuery request, CancellationToken cancellationToken)
    {
        var query = _unitOfWork.OrderRepository.GetQueryableSet();

        var result = query.Where(o => o.Id == request.Id)
            .Select(o => new OrderDto()
            {
                Id = o.Id,
                Status = o.Status,
                TotalPrice = o.TotalPrice,
                UserId = o.UserId,
                Date = o.CreatedDateTime,
                Items = o.Items.Select(i => new OrderItemDto()
                {
                    Price = i.Price,
                    Quantity = i.Quantity,
                    ProductThumbUrl = i.Product.ProductThumbUrl,
                    ProductName = i.Product.Name,
                    ProductId = i.ProductId
                }).ToList()
            }).FirstOrDefault();

        return result ?? throw new NotFoundException($"Order {request.Id} not found.");
    }
}