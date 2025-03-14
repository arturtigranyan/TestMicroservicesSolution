using Microsoft.AspNetCore.Mvc;
using Test.Core.DTO;
using Test.Core.ServiceContracts;

[ApiController]
[Route("api/[controller]")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegisterDto request)
    {
        var response = await authService.RegisterAsync(request);
        return Ok(response);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto request)
    {
        var response = await authService.LoginAsync(request);
        return Ok(response);
    }
}