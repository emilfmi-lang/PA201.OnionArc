using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Interfaces;
using OnionArch.Application.Models;
using OnionArch.Application.Services.Interfaces;
using OnionArch.Domain.Entities;


namespace OnionArch.Application.Services.Concretes;

public class CategoryService(IApplicationDbContext dbContext, IMapper mapper,
    IValidator<CategoryCreateDto> validator) : ICategoryService
{
    public async Task<ResponseModel<CategoryReturnDto>> CreateCategoryAsync(CategoryCreateDto categoryDto)
    {
        if (await dbContext.Categories.AnyAsync(c => c.Name == categoryDto.Name))
            throw new Exception("Category with the same name already exists.");
        var validationResult = await validator.ValidateAsync(categoryDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return ResponseModel<CategoryReturnDto>.Failure(errors);
        }

        var category = mapper.Map<Category>(categoryDto);
        await dbContext.Categories.AddAsync(category);
        await dbContext.SaveChangesAsync();
        var categoryReturnDto = mapper.Map<CategoryReturnDto>(category);
        return ResponseModel<CategoryReturnDto>.Success(categoryReturnDto);
    }

    public async Task<ResponseModel<bool>> DeleteCategoryAsync(int id)
    {
        var category = await dbContext.Categories.FindAsync(id);
        if (category == null)
            return ResponseModel<bool>.Failure("Category not found.");
        dbContext.Categories.Remove(category);
        await dbContext.SaveChangesAsync();
        return ResponseModel<bool>.Success(true);
    }

    public async Task<ResponseModel<List<CategoryReturnDto>>> GetAllCategoriesAsync()
    {
        var categories = await dbContext.Categories
            .ToListAsync();
        var categoriesDto = mapper.Map<List<CategoryReturnDto>>(categories);
        return ResponseModel<List<CategoryReturnDto>>.Success(categoriesDto);

    }
}
