using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using OnionArch.Application.Profiles;
using OnionArch.Application.Services.Concretes;
using OnionArch.Application.Services.Interfaces;
using OnionArch.Domain.Entities;

namespace OnionArch.Application;

public static class ServiceRegistration
{
    extension(IServiceCollection services)
    {
        public void AddApplicationServices()
        {
            services.AddAutoMapper(cfg => { cfg.AddProfile<MapProfile>(); });
            services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly);
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IColorServices, ColorService>();
        }
    }
}
