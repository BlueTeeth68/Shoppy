using AutoFixture;
using Moq;
using Shoppy.Application.Features.Orders.Handlers.Command;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Services.Interfaces;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Identity;
using Shoppy.SharedLibrary.Models.Responses.Carts;

namespace Application.Test.Features.Orders.Handlers.Command;

public class CreateCommandHandlerTest : TestBase
{
    private readonly Mock<ICurrentUser> _currentUserMock;
    private readonly Mock<IUserService> _serviceMock;
    private readonly CreateCommandHandler _handler;

    public CreateCommandHandlerTest()
    {
        _currentUserMock = new Mock<ICurrentUser>();
        _serviceMock = new Mock<IUserService>();
        _handler = new CreateCommandHandler(UnitOfWorkMock.Object, _currentUserMock.Object, _serviceMock.Object);
    }

    [Fact]
    public async Task Handle_ShouldCreateOrder_WhenUserIsAuthenticated()
    {
        // Arrange
        var createOrderCommand = Fixture.Build<CreateOrderCommand>().Create();
        var cartDto = Fixture.Build<CartDto>().Create();
        var currentId = Guid.NewGuid();

        _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
        _currentUserMock.Setup(x => x.UserId).Returns(currentId);
        _serviceMock.Setup(x => x.GetUserCartDetailAsync()).ReturnsAsync(cartDto);
        UnitOfWorkMock.Setup(x => x.OrderRepository.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        UnitOfWorkMock.Setup(x => x.SaveChangeAsync()).ReturnsAsync(1);
        _serviceMock.Setup(x => x.RemoveCartAsync(It.IsAny<CancellationToken>())).Returns(Task.CompletedTask);

        // Act
        await _handler.Handle(createOrderCommand, CancellationToken.None);

        // Assert
        _currentUserMock.Verify(x => x.IsAuthenticated, Times.Once);
        _currentUserMock.Verify(x => x.UserId, Times.Once);
        _serviceMock.Verify(x => x.GetUserCartDetailAsync(), Times.Once);
        UnitOfWorkMock.Verify(x => x.OrderRepository.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()),
            Times.Once);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Once);
        _serviceMock.Verify(x => x.RemoveCartAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task Handle_ShouldThrowException_WhenUserIsNotAuthenticated()
    {
        // Arrange
        var createOrderCommand = new CreateOrderCommand();

        _currentUserMock.Setup(x => x.IsAuthenticated).Returns(false);

        // Act & Assert
        await Assert.ThrowsAsync<ForbiddenException>(() => _handler.Handle(createOrderCommand, CancellationToken.None));

        _currentUserMock.Verify(x => x.IsAuthenticated, Times.Once);
        _serviceMock.Verify(x => x.GetUserCartDetailAsync(), Times.Never);
        UnitOfWorkMock.Verify(x => x.OrderRepository.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()),
            Times.Never);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Never);
        _serviceMock.Verify(x => x.RemoveCartAsync(It.IsAny<CancellationToken>()), Times.Never);
    }

    [Fact]
    public async Task Handle_ShouldNotCreateOrder_WhenUserCartIsEmpty()
    {
        // Arrange
        var createOrderCommand = new CreateOrderCommand();
        var emptyCartDto = Fixture.Build<CartDto>()
            .With(c => c.Items, () => [])
            .Create();
        var currentId = Guid.NewGuid();

        _currentUserMock.Setup(x => x.IsAuthenticated).Returns(true);
        _currentUserMock.Setup(x => x.UserId).Returns(currentId);
        _serviceMock.Setup(x => x.GetUserCartDetailAsync()).ReturnsAsync(emptyCartDto);

        // Act
        await _handler.Handle(createOrderCommand, CancellationToken.None);

        // Assert
        _currentUserMock.Verify(x => x.IsAuthenticated, Times.Once);
        _serviceMock.Verify(x => x.GetUserCartDetailAsync(), Times.Once);
        UnitOfWorkMock.Verify(x => x.OrderRepository.AddAsync(It.IsAny<Order>(), It.IsAny<CancellationToken>()),
            Times.Never);
        UnitOfWorkMock.Verify(x => x.SaveChangeAsync(), Times.Never);
        _serviceMock.Verify(x => x.RemoveCartAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}