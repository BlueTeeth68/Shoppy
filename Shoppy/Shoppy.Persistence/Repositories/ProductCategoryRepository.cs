﻿using Microsoft.Extensions.Logging;
using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories;
using Shoppy.Persistence.Repositories.Base;

namespace Shoppy.Persistence.Repositories;

public class ProductCategoryRepository: BaseRepository<ProductCategory, Guid>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext dbContext, ILogger<ProductCategory> logger) : base(dbContext, logger)
    {
    }
}