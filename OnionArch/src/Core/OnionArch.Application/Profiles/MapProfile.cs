
using AutoMapper;
using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Dtos.Product;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Enums;

namespace OnionArch.Application.Profiles;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Category, CategoryReturnDto>()
            .ConstructUsing(c => new CategoryReturnDto(c.Id, c.Name));
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<Product, ProductReturnDto>()
            .ConstructUsing(p => new ProductReturnDto(p.Name, p.Price, p.CategoryId, p.Status));
        CreateMap<ProductCreateDto, Product>();
    }
}
