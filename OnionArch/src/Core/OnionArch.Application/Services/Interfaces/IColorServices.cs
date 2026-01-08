
using OnionArch.Application.Dtos.Color;
using OnionArch.Application.Models;

namespace OnionArch.Application.Services.Interfaces;

public interface IColorServices
{
    Task<ResponseModel<List<ColorReturnDto>>> GetAllColorsAsync();
    Task<ResponseModel<ColorReturnDto>> CreateColorAsync(ColorCreateDto colorDto);
    Task<ResponseModel<bool>> DeleteColorAsync(int id);
    Task<ResponseModel<ColorReturnDto>> GetColorByIdAsync(int id);
}
