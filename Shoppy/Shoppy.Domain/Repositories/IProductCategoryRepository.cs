﻿using Shoppy.Domain.Entities;
using Shoppy.Domain.Repositories.Base;

namespace Shoppy.Domain.Repositories;

public interface IProductCategoryRepository: IBaseRepository<ProductCategory, Guid>
{
    
}