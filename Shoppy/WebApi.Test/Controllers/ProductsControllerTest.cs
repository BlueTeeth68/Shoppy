using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Domain.Constants;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.WebAPI.Controllers;

namespace WebApi.Test.Controllers;

public class ProductsControllerTest : TestBase
{
    private readonly ProductsController _controller;

    public ProductsControllerTest()
    {
        _controller = new ProductsController(MediatorMock.Object);

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
    public async Task AddAsync_WithValidRequest_ShouldReturnCreatedResult()
    {
        // Arrange
        var bytes = "Product thumb"u8.ToArray();
        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.png");
        
        var createProductCommandMock = Fixture.Build<CreateProductCommand>()
            .With(c => c.ProductThumb, () => file)
            .Create();
        var expectedGuid = Guid.NewGuid();

        MediatorMock.Setup(m => m.Send(createProductCommandMock, CancellationToken.None))
            .ReturnsAsync(expectedGuid);

        // Act
        
        var response = await _controller.AddAsync(createProductCommandMock);
        var createdResult = (CreatedResult)response.Result!;
        var result = (BaseResult<Guid>)createdResult.Value!;

        // Assert
        createdResult.StatusCode.Should().Be(StatusCodes.Status201Created);
        result.Should().BeOfType<BaseResult<Guid>>();
        result.Result.Should().NotBe(Guid.Empty);
        result.IsSuccess.Should().BeTrue();
        result.Result.Should().Be(expectedGuid);
    }
}