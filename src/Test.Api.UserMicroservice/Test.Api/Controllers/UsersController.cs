using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Test.Core.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;

namespace Test.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class UsersController(UserManager<ApplicationUser> userManager) : ControllerBase
{
    [HttpGet("profile")]
    public async Task<IActionResult> GetUserProfile()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (string.IsNullOrEmpty(userId))
            return Unauthorized();

        var user = await userManager.FindByIdAsync(userId);
        if (user is null)
            return NotFound("User not found.");

        var roles = await userManager.GetRolesAsync(user);

        return Ok(new
        {
            user.UserName,
            user.Email,
            Roles = roles
        });
    }
}
