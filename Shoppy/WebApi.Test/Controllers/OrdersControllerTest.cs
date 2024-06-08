using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Orders.Requests.Command;
using Shoppy.Application.Features.Orders.Requests.Query;
using Shoppy.Application.Features.ProductRatings.Request.Command;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Orders;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class OrdersControllerTest : TestBase
{
    private readonly OrdersController _controller;

    public OrdersControllerTest()
    {
        _controller = new OrdersController(MediatorMock.Object);
        // Set up the user's claims
        var user = new ClaimsPrincipal(new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.Role, RoleConstant.AdminRole)
        }));
        _controller.ControllerContext = new ControllerContext
        {
            HttpContext = new DefaultHttpContext
            {
                User = user
            }
        };
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        MediatorMock.Setup(m => m.Send(It.IsAny<CreateOrderCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.CreateAsync();
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task GetUserOrderAsync_ShouldReturnCorrectData()
    {
        //Arrange 
        var expectedData = Fixture.Build<PagingResult<OrderQueryDto>>().Create();
        var requestMock = Fixture.Build<GetUserOrderQuery>().Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<GetUserOrderQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);
        //Act
        var response = await _controller.GetUserOrderAsync(requestMock);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<PagingResult<OrderQueryDto>>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeOfType<PagingResult<OrderQueryDto>>();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var expectedData = Fixture.Build<OrderDto>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<GetOrderDetailQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.GetByIdAsync(Guid.NewGuid());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<OrderDto>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeOfType<OrderDto>();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task AddRatingAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        var requestMock = Fixture.Build<CreateRatingCommand>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<CreateRatingCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        //Act
        var response = await _controller.AddRatingAsync(requestMock, requestMock.OrderItemId);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task AddRatingAsync_ShouldThrowBadRequestStatus()
    {
        //Arrange

        var requestMock = Fixture.Build<CreateRatingCommand>()
            .With(r => r.OrderItemId, () => new Guid("869cbb6d-0bbd-4351-b5d4-ecc2b5d880fc"))
            .Create();
        var id = new Guid("bca03fa1-f138-4cb1-913e-992cee2f1cf5");
        MediatorMock.Setup(m => m.Send(It.IsAny<CreateRatingCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        //Act

        //Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.AddRatingAsync(requestMock, id));
    }
}