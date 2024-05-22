using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Categories;

namespace Shoppy.WebMVC.Services.Interfaces;

public interface ICategoryService
{
    Task<BaseResult<List<CategoryDto>>?> GetAllAsync();
}