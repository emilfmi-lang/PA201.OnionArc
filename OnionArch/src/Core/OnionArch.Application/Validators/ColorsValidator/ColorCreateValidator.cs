

using FluentValidation;
using OnionArch.Application;
using OnionArch.Application.Dtos.Color;

namespace OnionArch.Application.Validators.ColorsValidator;

public class ColorCreateValidator : AbstractValidator<ColorCreateDto>
{
    public ColorCreateValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty().WithMessage("Color name is required.")
            .MaximumLength(20).WithMessage("Color name must not exceed 20 characters.");
    }
}
