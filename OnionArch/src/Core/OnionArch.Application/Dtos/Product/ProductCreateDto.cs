using FluentValidation;
using OnionArch.Domain.Enums;

namespace OnionArch.Application.Dtos.Product;

public record ProductCreateDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ProductStatus Status { get; set; }
    public int CategoryId { get; set; }

}

public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
{
    public ProductCreateDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");
        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
    }
}
