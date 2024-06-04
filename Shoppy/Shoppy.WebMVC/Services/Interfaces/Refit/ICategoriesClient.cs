using Refit;
using Shoppy.SharedLibrary.Models.Base;
using Shoppy.SharedLibrary.Models.Responses.Categories;

namespace Shoppy.WebMVC.Services.Interfaces.Refit;

public interface ICategoriesClient
{
    [Get("/categories")]
    Task<BaseResult<List<CategoryDto>>?> GetAllAsync();
}