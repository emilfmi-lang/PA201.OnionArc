
using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using OnionArch.Application.Dtos.Color;
using OnionArch.Application.Interfaces;
using OnionArch.Application.Models;
using OnionArch.Application.Services.Interfaces;
using OnionArch.Domain.Entities;

using System.Drawing;
using Color = OnionArch.Domain.Entities.Color;

namespace OnionArch.Application.Services.Concretes;

public class ColorService(IApplicationDbContext dbContext,IMapper mapper,
    IValidator<ColorCreateDto> validator
    ) : IColorServices
{
    public async Task<ResponseModel<ColorReturnDto>> CreateColorAsync(ColorCreateDto colorDto)
    {
        if(await dbContext.Colors.AnyAsync(c => c.Name.ToLower() == colorDto.Name.ToLower()))
            return ResponseModel<ColorReturnDto>.Failure("Color with the same name already exists.");
        var validationResult = await validator.ValidateAsync(colorDto);
        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return ResponseModel<ColorReturnDto>.Failure(errors);
        }
        var colorEntity = mapper.Map<Color>(colorDto);
        await dbContext.Colors.AddAsync(colorEntity);
        await dbContext.SaveChangesAsync();
        var colorReturnDto = mapper.Map<ColorReturnDto>(colorEntity);
        return ResponseModel<ColorReturnDto>.Success(colorReturnDto);
    }

    public async Task<ResponseModel<bool>> DeleteColorAsync(int id)
    {
        var color = await dbContext.Colors.FindAsync(id);
        if (color == null)
            return ResponseModel<bool>.Failure("Color not found.");
        dbContext.Colors.Remove(color);
        await dbContext.SaveChangesAsync();
        return ResponseModel<bool>.Success(true);
    }

    public async Task<ResponseModel<List<ColorReturnDto>>> GetAllColorsAsync()
    {
        var colors = await dbContext.Colors.ToListAsync();
        var colorDtos = mapper.Map<List<ColorReturnDto>>(colors);
        return ResponseModel<List<ColorReturnDto>>.Success(colorDtos);
    }
    public async Task<ResponseModel<ColorReturnDto>> GetColorByIdAsync(int id)
    {
        var color = await dbContext.Colors.FindAsync(id);
        if (color == null)
            return ResponseModel<ColorReturnDto>.Failure("Color not found.");
        var colorDto = mapper.Map<ColorReturnDto>(color);
        return ResponseModel<ColorReturnDto>.Success(colorDto);
    }
}
