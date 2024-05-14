using Microsoft.Extensions.Logging;
using Shoppy.Domain.Repositories;
using Shoppy.Domain.Repositories.UnitOfWork;

namespace Shoppy.Persistence.Repositories.UnitOfWork;

public class UnitOfWork : IUnitOfWork
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
}