using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Carts.Request.Command;
using Shoppy.Application.Features.Carts.Request.Query;
using Shoppy.Application.Features.Users.Requests.Query;
using Shoppy.Application.Features.Users.Resutls;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Carts;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class UsersControllerTest : TestBase
{
    private readonly UsersController _controller;

    public UsersControllerTest()
    {
        _controller = new UsersController(MediatorMock.Object);

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
    public async Task FilterUsersAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var expectedData = new PagingResult<FilterUserResult>()
        {
            TotalPages = 0,
            TotalRecords = 0,
            Results = []
        };

        MediatorMock.Setup(m => m.Send(It.IsAny<FilterUserQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.FilterUsersAsync(new FilterUserQuery());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<PagingResult<FilterUserResult>>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<PagingResult<FilterUserResult>>>();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetUserCartAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var expectedData = Fixture.Build<CartDto>().Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<GetUserCartDetailQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.GetUserCartAsync();
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<CartDto>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<CartDto>>();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetCartTotalItemAsync_ShouldReturnCorrectData()
    {
        //Arrange
        const int expectedData = 10;

        MediatorMock.Setup(m => m.Send(It.IsAny<GetCartTotalItemQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.GetCartTotalItemAsync();
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<int>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<int>>();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().Be(expectedData);
    }

    [Fact]
    public async Task AddToCartAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var inputData = Fixture.Build<AddCartItemCommand>().Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<AddCartItemCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.AddToCartAsync(inputData);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task UpdateCartQuantity_ShouldReturnSuccessStatus()
    {
        //Arrange
        var inputData = Fixture.Build<UpdateCartItemCommand>().Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateCartItemCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        
        //Act
        var response = await _controller.UpdateCartQuantity(inputData);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task RemoveFromCartAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        MediatorMock.Setup(m => m.Send(It.IsAny<RemoveCartItemCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        
        //Act
        var response = await _controller.RemoveFromCartAsync(Guid.NewGuid());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }
}