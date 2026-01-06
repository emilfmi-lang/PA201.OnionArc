using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Services.Interfaces;

namespace OnionArch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController(ICategoryService categoryService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllCategories()
    {
        var categories = await categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }
    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryCreateDto createDto)
    {
        await categoryService.CreateCategoryAsync(createDto);
        return Ok();
    }
}
