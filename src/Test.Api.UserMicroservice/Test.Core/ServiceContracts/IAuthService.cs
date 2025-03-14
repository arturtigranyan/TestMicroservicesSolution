using Test.Core.DTO;

namespace Test.Core.ServiceContracts;

public interface IAuthService
{
    Task<AuthResponse> RegisterAsync(UserRegisterDto request);
    Task<AuthResponse> LoginAsync(UserLoginDto request);
}