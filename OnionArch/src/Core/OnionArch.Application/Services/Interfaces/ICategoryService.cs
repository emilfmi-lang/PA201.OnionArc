using OnionArch.Application.Dtos.Category;

namespace OnionArch.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<List<CategoryReturnDto>> GetAllCategoriesAsync();
    Task CreateCategoryAsync(CategoryCreateDto categoryDto);
}




