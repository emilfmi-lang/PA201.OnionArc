

using FluentValidation;
using OnionArch.Application.Dtos.AppUser;

namespace OnionArch.Application.Validators.AccountValidator;

public class AppUserRegisterValidator: AbstractValidator<UserRegisterDto>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("Username boş ola bilməz")
            .MinimumLength(3).WithMessage("Username minimum 3 simvol olmalıdır")
            .MaximumLength(50).WithMessage("Username maksimum 50 simvol ola bilər");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email boş ola bilməz")
            .EmailAddress().WithMessage("Email formatı yanlışdır");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Şifrə boş ola bilməz")
            .MinimumLength(6).WithMessage("Şifrə minimum 6 simvol olmalıdır")
            .Matches("[A-Z]").WithMessage("Şifrə ən azı 1 böyük hərf içerməlidir")
            .Matches("[a-z]").WithMessage("Şifrə ən azı 1 kiçik hərf içerməlidir")
            .Matches("[0-9]").WithMessage("Şifrə ən azı 1 rəqəm içerməlidir");

        RuleFor(x => x.FullName)
            .NotEmpty().WithMessage("Ad Soyad boş ola bilməz")
            .MinimumLength(3).WithMessage("Ad Soyad minimum 3 simvol olmalıdır");
    }
}
