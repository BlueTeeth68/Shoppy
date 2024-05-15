namespace Shoppy.Domain.Repositories.UnitOfWork;

public interface IUnitOfWork
{
    IAddressRepository AddressRepository { get; }
    ICartItemRepository CartItemRepository { get; }
    IOrderRepository OrderRepository { get; }
    IOrderItemRepository OrderItemRepository { get; }
    IProductCategoryRepository ProductCategoryRepository { get; }
    IProductRatingRepository ProductRatingRepository { get; }
    IProductRepository ProductRepository { get; }

    Task<int> SaveChangeAsync();
}