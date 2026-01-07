
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Dtos.Color;
using OnionArch.Application.Interfaces;
using OnionArch.Application.Models;
using OnionArch.Application.Services.Interfaces;

namespace OnionArch.Application.Services.Concretes;

public class ColorService(IApplicationDbContext dbContext,IMapper mapper) : IColorServices
{
    public Task<ResponseModel<ColorReturnDto>> CreateColorAsync(ColorCreateDto colorDto)
    {
        throw new NotImplementedException();
    }

    public async Task<ResponseModel<List<ColorReturnDto>>> GetAllColorsAsync()
    {
        var colors = await dbContext.Colors.ToListAsync();
        var colorDtos = mapper.Map<List<ColorReturnDto>>(colors);
        return ResponseModel<List<ColorReturnDto>>.Success(colorDtos);
    }
}
