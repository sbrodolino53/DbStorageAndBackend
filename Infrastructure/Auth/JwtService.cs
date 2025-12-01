using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MinimalApiTemplate.Features.Users;

namespace MinimalApiTemplate.Infrastructure.Auth;

public sealed class JwtService
{
    private readonly byte[] _key;
    public JwtService(byte[] key) => _key = key;

    public string CreateToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email,        user.Email),
            new Claim(ClaimTypes.Role,         user.Role)
        };

        var creds = new SigningCredentials(new SymmetricSecurityKey(_key),
                                           SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(claims: claims,
                                       expires: DateTime.UtcNow.AddMinutes(15),
                                       signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }
}