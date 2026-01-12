using FluentValidation;
using OnionArch.Application.Dtos.AppUser;

namespace OnionArch.Application.Validators.AccountValidator;

public class AppUserLoginValidator : AbstractValidator<UserLoginDto>
{
    public AppUserLoginValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Username və ya Email boş ola bilməz");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrə boş ola bilməz")
            .MinimumLength(6).WithMessage("Şifrə minimum 6 simvol olmalıdır");
    }
}
