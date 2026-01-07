using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Dtos.Product;
using OnionArch.Application.Services.Interfaces;

namespace OnionArch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        var response = await productService.GetAllProductsAsync();
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateProduct([FromBody] ProductCreateDto createDto)
    {
        var response = await productService.CreateProductAsync(createDto);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        var response = await productService.ProductGetByIdAsync(id);
        return Ok(response);
    }
}
