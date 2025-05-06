using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinSystem.Entities;
using FinSystem.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FinSystem.Providers;

public class JwtProvider(IOptions<JwtOptions> options)
{
    private readonly JwtOptions _options = options.Value;

    public string GenerateJwtToken(User user)
    {
        //Claim[] claims = [new("username", user.Username), new("role", user.Role.ToString())];

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Username),
            new Claim(ClaimTypes.Role, user.Role.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        
        
        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: DateTime.UtcNow.AddHours(_options.ExpiredHours),
            signingCredentials: creds
            );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}