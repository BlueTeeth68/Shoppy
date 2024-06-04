using Bogus;
using Bogus.Extensions;
using Shoppy.Domain.Constants.Enums;
using Shoppy.Domain.Entities;

namespace Application.Test.FakeData;

public static class DataGenerator
{
    public static Faker<Product> GetProductGenerator(Guid? categoryId )
    {
        return new Faker<Product>()
            .RuleFor(p => p.Id, _ => Guid.NewGuid())
            .RuleFor(p => p.Quantity, f => f.Random.Int(0, 10000))
            .RuleFor(p => p.Price, f => f.Random.Decimal2(0, 100))
            .RuleFor(p => p.ProductThumbUrl, f => f.Image.PicsumUrl())
            .RuleFor(p => p.Name, f => f.Commerce.ProductName())
            .RuleFor(p => p.CategoryId, _ => categoryId)
            .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
            .RuleFor(p => p.Publisher, f => f.Company.CompanyName())
            .RuleFor(p => p.AuthorName, f => f.Person.FullName)
            .RuleFor(p => p.NumberOfPage, f => f.Random.Int(150, 600))
            .RuleFor(p => p.Status, _ => ProductStatus.Active)
            .RuleFor(p => p.CreatedDateTime, _ => DateTime.UtcNow)
            .RuleFor(p => p.IsDelete, _ => false)
            .RuleFor(p => p.NumberOfSale, _ => 0)
            .RuleFor(p => p.DateOfPublication, f => f.Date.Past(yearsToGoBack: 20));
    }

    public static Faker<CartItem> GetCartItemGenerator(Product? product, Guid? cartId)
    {
        return new Faker<CartItem>()
            .RuleFor(c => c.Product, _ => product)
            .RuleFor(c => c.Id, _ => Guid.NewGuid())
            .RuleFor(c => c.ProductId, _ => product?.Id)
            .RuleFor(c => c.Quantity, f => f.Random.Int(1, 10))
            .RuleFor(c => c.Status, _ => CartItemStatus.Available)
            .RuleFor(c => c.CartId, _ => cartId);
    }
}