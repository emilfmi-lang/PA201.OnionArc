namespace OnionArch.Application.Dtos.AppUser;

public record UserLoginDto
{ 
    public string Email { get; init; }
    public string Password { get; init; }
}
