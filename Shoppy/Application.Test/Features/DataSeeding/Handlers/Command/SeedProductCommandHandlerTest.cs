using Moq;
using Shoppy.Application.Features.DataSeeding.Handlers.Command;
using Shoppy.Application.Features.DataSeeding.Requests.Command;
using Shoppy.Application.Services.Interfaces;

namespace Application.Test.Features.DataSeeding.Handlers.Command;

public class SeedProductCommandHandlerTest: TestBase
{
    private readonly Mock<IProductService> _serviceMock;
    private readonly SeedProductCommandHandler _handler;

    public SeedProductCommandHandlerTest()
    {
        _serviceMock = new Mock<IProductService>();
        _handler = new SeedProductCommandHandler(_serviceMock.Object);
    }
    
    [Fact]
    public async Task Handle_ShouldCallSeedDataAsync_WithCorrectParameters()
    {
        // Arrange
        var request = new SeedProductCommand
        {
            Size = 50,
            CategoryId = Guid.NewGuid()
        };

        // Act
        await _handler.Handle(request, CancellationToken.None);

        // Assert
        _serviceMock.Verify(
            s => s.SeedDataAsync(request.Size, request.CategoryId, It.IsAny<CancellationToken>()),
            Times.Once);
    }
}