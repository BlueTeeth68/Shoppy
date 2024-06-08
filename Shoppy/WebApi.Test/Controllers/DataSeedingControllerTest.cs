using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class DataSeedingControllerTest : TestBase
{
    private readonly DataSeedingController _controller;

    public DataSeedingControllerTest()
    {
        _controller = new DataSeedingController(MediatorMock.Object);
    }

    [Fact]
    public async Task SeedUserAsync_ShouldReturnSuccessStatusCode()
    {
        //Arrange
        MediatorMock.Setup(m => m.Send(It.IsAny<SeedUserCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.SeedUserAsync(10);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }
    [Fact]
    public async Task SeedProductAsync_ShouldReturnSuccessStatusCode()
    {
        //Arrange
        var requestMock = Fixture.Build<SeedProductCommand>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<SeedProductCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.SeedProductAsync(requestMock);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }
}