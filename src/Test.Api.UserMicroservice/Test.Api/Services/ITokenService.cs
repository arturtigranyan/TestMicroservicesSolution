using Test.Core.Entities;

public interface ITokenService
{
    Task<object> GenerateTokenAsync(ApplicationUser user, IList<string> roles);
}
