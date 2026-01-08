using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArch.Application.Attributes;
using OnionArch.Domain.Enums;
using System.ComponentModel.DataAnnotations;


namespace OnionArch.Application.Dtos.Product;

public record ProductCreateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ProductStatus Status { get; set; }
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Şəkil mütləq yüklənməlidir.")]
    [FileLength(2 * 1024 * 1024)] 
    [FileType(new string[] { ".jpg", ".jpeg", ".png" })]
    public IFormFile ImageFile { get; set; }

}

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(20).WithMessage("Product name cannot exceed 20 characters.");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");
        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
    }
}
