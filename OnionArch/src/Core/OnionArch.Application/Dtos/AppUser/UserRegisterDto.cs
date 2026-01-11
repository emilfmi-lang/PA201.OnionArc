namespace OnionArch.Application.Dtos.AppUser;

public record UserRegisterDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
}
