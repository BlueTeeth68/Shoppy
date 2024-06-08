using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Authentication.Requests.Command;
using Shoppy.Application.Features.Authentication.Results.Command;
using Shoppy.Domain.Constants;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class AuthenticationControllerTest : TestBase
{
    private readonly AuthenticationController _controller;

    public AuthenticationControllerTest()
    {
        _controller = new AuthenticationController(MediatorMock.Object);

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
    public async Task LoginAsync_ShouldReturnCorrectData()
    {
        //Arrange 
        var requestMock = Fixture.Build<LoginCommand>().Create();
        var expectedData = Fixture.Build<LoginResponse>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<LoginCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        // Act

        var response = await _controller.LoginAsync(requestMock);
        var createdResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<LoginResponse>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<LoginResponse>>();
        result.Result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task RegisterAsync_ShouldReturnCorrectData()
    {
        //Arrange 
        var requestMock = Fixture.Build<RegisterCommand>().Create();
        var expectedData = Fixture.Build<RegisterResponse>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<RegisterCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        // Act

        var response = await _controller.RegisterAsync(requestMock);
        var createdResult = (CreatedResult)response.Result!;
        var result = (BaseResult<RegisterResponse>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);
        result.Should().BeOfType<BaseResult<RegisterResponse>>();
        result.Result.Should().NotBeNull();
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().BeEquivalentTo(expectedData);
    }
}