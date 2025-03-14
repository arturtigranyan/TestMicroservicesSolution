using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Test.Core.Entities;

namespace Test.Core.Services;

public class TokenService(IConfiguration config) : ITokenService
{
    public Task<object> GenerateTokenAsync(ApplicationUser user, IList<string> roles)
    {
        var claims = new List<Claim>
    {
        new(JwtRegisteredClaimNames.Sub, user.Id),
        new(JwtRegisteredClaimNames.Email, user.Email!)
    };

        // Add dynamic roles to claims
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtSettings:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDuration = double.TryParse(config["JwtSettings:DurationInMinutes"], out var minutes)
            ? minutes
            : 60;

        var token = new JwtSecurityToken(
            issuer: config["JwtSettings:Issuer"],
            audience: config["JwtSettings:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tokenDuration),
            signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

        return Task.FromResult<object>(new
        {
            Token = tokenString,
            Expiration = token.ValidTo
        });
    }
}