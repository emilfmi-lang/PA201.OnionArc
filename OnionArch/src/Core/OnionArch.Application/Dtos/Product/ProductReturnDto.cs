
using FluentValidation;
using OnionArch.Domain.Enums;

namespace OnionArch.Application.Dtos.Product;

public record ProductReturnDto(string Name, decimal Price, int CategoryId,ProductStatus ProductStatus);

public class ProductReturnDtoValidator : AbstractValidator<ProductReturnDto>
{
    public ProductReturnDtoValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("Product name is required.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");
        RuleFor(p => p.Price)
            .GreaterThan(0).WithMessage("Product price must be greater than zero.");
        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be a positive integer.");
        RuleFor(p => p.ProductStatus)
                        .IsInEnum().WithMessage("Invalid product status.");
    }
}
