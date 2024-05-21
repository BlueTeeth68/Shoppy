﻿using Shoppy.Domain.Repositories.Base;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Requests.Products;
using Shoppy.SharedLibrary.Models.Responses.Products;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface IProductService
{
    Task<BaseResult<PagingResult<FilterProductResponse>>?> FilterProductAsync(FilterProductRequest request);
}