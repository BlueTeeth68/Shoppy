using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Shoppy.Domain.Exceptions;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Persistence.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IAsyncDisposable
{
    private readonly AppDbContext _dbContext;
    private readonly ILogger<UnitOfWork> _logger;

    public IAddressRepository AddressRepository { get; }
    public ICartItemRepository CartItemRepository { get; }
    public IOrderRepository OrderRepository { get; }
    public IOrderItemRepository OrderItemRepository { get; }
    public IProductCategoryRepository ProductCategoryRepository { get; }
    public IProductRatingRepository ProductRatingRepository { get; }
    public IProductRepository ProductRepository { get; }

    public UnitOfWork(AppDbContext dbContext, ILogger<UnitOfWork> logger, IAddressRepository addressRepository,
        ICartItemRepository cartItemRepository, IOrderRepository orderRepository,
        IOrderItemRepository orderItemRepository, IProductCategoryRepository productCategoryRepository,
        IProductRatingRepository productRatingRepository, IProductRepository productRepository)
    {
        _dbContext = dbContext;
        _logger = logger;
        AddressRepository = addressRepository;
        CartItemRepository = cartItemRepository;
        OrderRepository = orderRepository;
        OrderItemRepository = orderItemRepository;
        ProductCategoryRepository = productCategoryRepository;
        ProductRatingRepository = productRatingRepository;
        ProductRepository = productRepository;
    }

    public async Task<int> SaveChangeAsync()
    {
        try
        {
            return await _dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException e)
        {
            throw new ConflictException("The data has been update by someone else. Try reload and do again");
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    private bool _disposed = false;

    protected virtual async Task DisposeAsync(bool disposing)
    {
        if (!this._disposed)
        {
            if (disposing)
            {
                await _dbContext.DisposeAsync();
            }
        }

        this._disposed = true;

        await Task.CompletedTask;
    }

    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
}