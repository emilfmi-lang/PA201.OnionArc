using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Dtos.Color;
using OnionArch.Application.Services.Interfaces;

namespace OnionArch.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ColorController(IColorServices colorServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllColors()
    {
        var response = await colorServices.GetAllColorsAsync();
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateColor(ColorCreateDto createDto)
    {
        var response = await colorServices.CreateColorAsync(createDto);
        return Ok(response);
    }
}
