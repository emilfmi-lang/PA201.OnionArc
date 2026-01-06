
using AutoMapper;
using OnionArch.Application.Dtos.Category;
using OnionArch.Domain.Entities;

namespace OnionArch.Application.Profiles;

public class MapProfile:Profile
{
    public MapProfile()
    {
        CreateMap<Category, CategoryReturnDto>()
            .ConstructUsing(c => new CategoryReturnDto(c.Id, c.Name));
        CreateMap<CategoryCreateDto, Category>();
    }
}
