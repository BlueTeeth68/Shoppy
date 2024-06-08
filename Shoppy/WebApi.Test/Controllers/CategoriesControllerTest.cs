using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Categories.Requests.Command;
using Shoppy.Application.Features.Categories.Requests.Query;
using Shoppy.Application.Features.Categories.Results.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class CategoriesControllerTest : TestBase
{
    private readonly CategoriesController _controller;

    public CategoriesControllerTest()
    {
        _controller = new CategoriesController(MediatorMock.Object);

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
    public async Task GetAlLAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var expectedData = Fixture.Build<CategoryResult>().CreateMany(4).ToList();
        MediatorMock.Setup(m => m.Send(It.IsAny<GetAllCategoriesQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);
        //Act
        var response = await _controller.GetAlLAsync();
        var createdResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<List<CategoryResult>>)createdResult.Value!;

        // Assert

        createdResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<List<CategoryResult>>>();
        result.Result.Should().NotBeNullOrEmpty();
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var expectedData = Fixture.Build<CategoryResult>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.GetByIdAsync(Guid.NewGuid());
        var createdResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<CategoryResult>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<CategoryResult>>();
        result.Result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task CreateAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        var requestMock = Fixture.Build<CreateCategoryCommand>().Create();
        var expectedId = Guid.NewGuid();
        MediatorMock.Setup(m => m.Send(It.IsAny<CreateCategoryCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedId);

        //Act
        var response = await _controller.CreateAsync(requestMock);
        var createdResult = (CreatedResult)response.Result!;
        var result = (BaseResult<Guid>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);
        result.Should().BeOfType<BaseResult<Guid>>();
        result.Result.Should().NotBe(Guid.Empty);
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().Be(expectedId);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        var requestMock = Fixture.Build<UpdateCategoryCommand>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        //Act
        var response = await _controller.UpdateAsync(requestMock.Id, requestMock);
        var createdResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowBadRequest()
    {
        //Arrange
        var requestMock = Fixture.Build<UpdateCategoryCommand>()
            .With(r => r.Id, () => new Guid("dbcf3e65-5d05-4903-9ea7-938fa73a351b"))
            .Create();
        var idMock = new Guid("b1855fbf-b02d-4cb6-b8fa-8f40b5b0f26c");
        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateCategoryCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);
        //Act
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.UpdateAsync(idMock, requestMock));
    }
}