

using OnionArch.Application.Dtos.Product;
using OnionArch.Application.Models;

namespace OnionArch.Application.Services.Interfaces;

public interface IProductService
{
    Task<ResponseModel<List<ProductReturnDto>>> GetAllProductsAsync();
    Task<ResponseModel<ProductReturnDto>> CreateProductAsync(ProductCreateDto productCreateDto);
    Task<ResponseModel<ProductReturnDto>>ProductGetByIdAsync(int id);
    Task<ResponseModel<bool>> DeleteProductAsync (int id);
}
