using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Models;

namespace OnionArch.Application.Services.Interfaces;

public interface ICategoryService
{
    Task<ResponseModel<CategoryReturnDto>> CreateCategoryAsync(CategoryCreateDto categoryDto);
    Task<ResponseModel<List<CategoryReturnDto>>> GetAllCategoriesAsync();
    Task<ResponseModel<bool>>  DeleteCategoryAsync(int id);
}




