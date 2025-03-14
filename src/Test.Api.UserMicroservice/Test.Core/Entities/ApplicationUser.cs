using Microsoft.AspNetCore.Identity;

namespace Test.Core.Entities;

public class ApplicationUser : IdentityUser
{
    public string? FullName { get; set; }
}
