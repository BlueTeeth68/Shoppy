using Microsoft.EntityFrameworkCore;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories.Base;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.SharedLibrary.Models.Responses.Orders;

namespace Shoppy.Infrastructure.Services;

public class OrderService : IOrderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICurrentUser _currentUser;

    public OrderService(IUnitOfWork unitOfWork, ICurrentUser currentUser)
    {
        _unitOfWork = unitOfWork;
        _currentUser = currentUser;
    }

    public async Task<PagingResult<OrderQueryDto>> FilterUserOrderAsync(int page, int size,
        CancellationToken cancellationToken = default)
    {
        var orderQuery = _unitOfWork.OrderRepository.GetQueryableSet();

        //get total record/page
        var totalRecord = await orderQuery.Where(o => o.UserId == _currentUser.UserId)
            .CountAsync(cancellationToken: cancellationToken);

        var data = await orderQuery.AsNoTracking().Where(o => o.UserId == _currentUser.UserId)
            .OrderByDescending(o => o.CreatedDateTime)
            .Select(o => new OrderQueryDto()
            {
                Id = o.Id,
                UserId = o.UserId,
                TotalPrice = o.TotalPrice,
                Status = o.Status,
                Date = o.CreatedDateTime
            })
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync(cancellationToken: cancellationToken);

        var totalPages = (int)Math.Ceiling((double)totalRecord / size);

        var result = new PagingResult<OrderQueryDto>()
        {
            TotalPages = totalPages,
            TotalRecords = totalRecord,
            Results = data
        };

        return result;
    }
}