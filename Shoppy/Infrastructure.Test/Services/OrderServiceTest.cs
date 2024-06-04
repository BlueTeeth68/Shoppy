using MockQueryable.Moq;
using Moq;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Identity;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Infrastructure.Services;

namespace Infrastructure.Test.Services;

public class OrderServiceTest
{
    private readonly Mock<IUnitOfWork> _unitOfWork;
    private readonly Mock<ICurrentUser> _currentUser;
    private readonly Mock<IOrderRepository> _orderRepository;
    private readonly IOrderService _orderService;

    public OrderServiceTest()
    {
        _unitOfWork = new Mock<IUnitOfWork>();
        _currentUser = new Mock<ICurrentUser>();
        _orderRepository = new Mock<IOrderRepository>();
        _orderService = new OrderService(_unitOfWork.Object, _currentUser.Object);
    }

    [Fact]
    public async Task FilterUserOrderAsync_Should_ReturnAPagingResult_WhenCalled()
    {
        //Arrange
        var userId = new Guid("de2ce734-c1cf-458f-9835-62f5d73d5ef8");
        var orders = new List<Order>()
        {
            new()
            {
                Id = Guid.NewGuid(),
                TotalPrice = 10,
                UserId = userId
            },
            new()
            {
                Id = Guid.NewGuid(),
                TotalPrice = 10,
                UserId = userId
            },
            new()
            {
                Id = Guid.NewGuid(),
                TotalPrice = 10,
                UserId = new Guid("d1a6a8c8-9e70-4b73-b092-3faa8cbec957")
            }
        };

        var mock = orders.AsQueryable().BuildMock();
        
        _unitOfWork.Setup(u => u.OrderRepository)
            .Returns(_orderRepository.Object);
        _orderRepository.Setup(o => o.GetQueryableSet())
            .Returns(mock);
        _currentUser.Setup(c => c.UserId)
            .Returns(userId);

        //Act
        var result = await _orderService.FilterUserOrderAsync(1, 8);

        //Assert
        Assert.NotNull(result);
        Assert.Equal(2, result.TotalRecords);
        Assert.Equal(1, result.TotalPages);
    }
}