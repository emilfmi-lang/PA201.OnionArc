using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Interfaces;
using OnionArch.Application.Services.Interfaces;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Services.Concretes;

public class CategoryService(IApplicationDbContext dbContext, IMapper mapper) : ICategoryService
{
    public async Task CreateCategoryAsync(CategoryCreateDto categoryDto)
    {
        var category = mapper.Map<Category>(categoryDto);
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<CategoryReturnDto>> GetAllCategoriesAsync()
    {
        var categories = await dbContext.Categories
            .ToListAsync();
        var categoriesDto = mapper.Map<List<CategoryReturnDto>>(categories);
        return categoriesDto;
    }
}
