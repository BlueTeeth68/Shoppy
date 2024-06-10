﻿using System.Security.Claims;
using AutoFixture;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shoppy.Application.Features.Products.Requests.Command;
using Shoppy.Application.Features.Products.Requests.Query;
using Shoppy.Application.Features.Products.Results.Query;
using Shoppy.Domain.Constants;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Products;
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

    #region AddAsync Test

    [Fact]
    public async Task AddAsync_ShouldReturnCreatedResult_WithValidRequest()
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

    #endregion

    [Fact]
    public async Task FilterAsync_ShouldReturnCorrectData_WithValidRequest()
    {
        //Arrange
        var expectedData = new PagingResult<FilterProductResult>()
        {
            TotalPages = 0,
            TotalRecords = 0,
            Results = []
        };

        MediatorMock.Setup(m => m.Send(It.IsAny<FilterProductQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.FilterAsync(new FilterProductQuery());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<PagingResult<FilterProductResult>>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.Should().BeOfType<BaseResult<PagingResult<FilterProductResult>>>();
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task GetByIdAsync_ShouldReturnCorrectData_WhenEntityExist()
    {
        //Arrange
        var expectedData = Fixture.Build<ProductDetailQueryResult>().Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<GetProductByIdQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.GetByIdAsync(Guid.NewGuid());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<ProductDetailQueryResult>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeOfType<ProductDetailQueryResult>();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task FilterProductRatingAsync_ShouldReturnCorrectData_WhenFilterValid()
    {
        //Arrange
        var expectedData = Fixture.Build<PagingResult<ProductRatingDto>>()
            .Create();
        MediatorMock.Setup(m => m.Send(It.IsAny<FilterProductRatingQuery>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.FilterProductRatingAsync(id: Guid.NewGuid(), null, null);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<PagingResult<ProductRatingDto>>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeOfType<PagingResult<ProductRatingDto>>();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task UpdateAsync_ShouldReturnOkStatusCode_WhenRequestIsValid()
    {
        //Arrange
        var bytes = "Product thumb"u8.ToArray();
        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.png");
        var inputData = Fixture.Build<UpdateProductCommand>()
            .With(p => p.ProductThumb, () => file)
            .Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.UpdateAsync(id: inputData.Id, inputData);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }

    [Fact]
    public async Task UpdateAsync_ShouldThrowBadRequest_WhenRequestIdIsNotMatch()
    {
        //Arrange
        var bytes = "Product thumb"u8.ToArray();
        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.png");
        var id = new Guid("bca03fa1-f138-4cb1-913e-992cee2f1cf5");
        var inputData = Fixture.Build<UpdateProductCommand>()
            .With(p => p.Id, () => new Guid("5d0f850a-45f5-4a52-ad77-85a871f71c33"))
            .With(p => p.ProductThumb, () => file)
            .Create();

        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act

        //Assert
        await Assert.ThrowsAsync<BadRequestException>(() => _controller.UpdateAsync(id, inputData));
    }

    [Fact]
    public async Task UpdateProductThumbAsync_ShouldReturnCorrectData()
    {
        //Arrange
        var bytes = "Product thumb"u8.ToArray();
        IFormFile file = new FormFile(new MemoryStream(bytes), 0, bytes.Length, "Data", "image.png");
        var inputData = Fixture.Build<UpdateProductImageCommand>()
            .With(p => p.File, () => file)
            .Create();
        const string expectedData = "https://www.uuidgenerator.net/guid";

        MediatorMock.Setup(m => m.Send(It.IsAny<UpdateProductImageCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(expectedData);

        //Act
        var response = await _controller.UpdateProductThumbAsync(inputData);
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<string>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
        result.Result.Should().BeOfType<string>();
        result.Result.Should().BeEquivalentTo(expectedData);
    }

    [Fact]
    public async Task DeleteAsync_ShouldReturnSuccessStatus()
    {
        //Arrange
        MediatorMock.Setup(m => m.Send(It.IsAny<DeleteProductCommand>(), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        //Act
        var response = await _controller.DeleteAsync(Guid.NewGuid());
        var okObjectResult = (OkObjectResult)response.Result!;
        var result = (BaseResult<object>)okObjectResult.Value!;

        //Assert
        okObjectResult.StatusCode.Should().Be(StatusCodes.Status200OK);
        result.IsSuccess.Should().BeTrue();
        result.Error.Should().BeNull();
    }
}