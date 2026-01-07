
using AutoMapper;
using OnionArch.Application.Dtos.Category;
using OnionArch.Application.Dtos.Color;
using OnionArch.Application.Dtos.Product;
using OnionArch.Domain.Entities;
using OnionArch.Domain.Enums;

namespace OnionArch.Application.Profiles;

public class MapProfile : Profile
{
    public MapProfile()
    {
        CreateMap<Category, CategoryReturnDto>()
            .ConstructUsing(c => new CategoryReturnDto(c.Id, c.Name));
        CreateMap<CategoryCreateDto, Category>();
        CreateMap<Product, ProductReturnDto>()
            .ConstructUsing(p => new ProductReturnDto(
                p.Name,
                p.Price,
                p.Category != null ? p.Category.Name : string.Empty,
                p.Status.ToString()
            ));
        //.ForMember(dest => dest.ProductStatusName, opt => opt.MapFrom(src => src.Status.ToString()))
        //.ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Color, ColorReturnDto>()
            .ConstructUsing(c => new ColorReturnDto(c.Name));
    }
}
