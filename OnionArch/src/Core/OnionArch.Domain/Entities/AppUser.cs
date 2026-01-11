

using Microsoft.AspNetCore.Identity;

namespace OnionArch.Domain.Entities;

public class AppUser: IdentityUser
{
    public string FullName { get; set; }
}
    