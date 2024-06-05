using AutoFixture;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.UnitOfWork;
using Shoppy.Persistence;

namespace Persistence.Test.Repositories;

public class TestBase : IDisposable
{
    protected readonly Fixture Fixture;
    protected readonly Mock<IUnitOfWork> UnitOfWorkMock;
    protected readonly Mock<IProductRepository> ProductRepoMock;
    protected readonly AppDbContext DbContext;

    public TestBase()
    {
        ProductRepoMock = new Mock<IProductRepository>();
        Fixture = new Fixture();
        UnitOfWorkMock = new Mock<IUnitOfWork>();
        ProductRepoMock = new Mock<IProductRepository>();

        var serviceProvider = new ServiceCollection()
            .AddEntityFrameworkInMemoryDatabase()
            .BuildServiceProvider();

        // Create a new options instance telling the context to use an
        // InMemory database and the new service provider.
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .UseInternalServiceProvider(serviceProvider)
            .Options;
        DbContext = new AppDbContext(options);
    }

    public void Dispose()
    {
        DbContext.Dispose();
    }
}