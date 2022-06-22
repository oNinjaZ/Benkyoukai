using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Benkyoukai.Application.Common.Interfaces.Authentication;
using Microsoft.IdentityModel.Tokens;

namespace Benkyoukai.Infrastructure.Authentication;

public class JwtTokenGenerator : IJwtTokenGenerator
{
    public string GenerateToken(Guid userId, string firstName, string lastName)
    {
        var claims = new []
        {
            new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
            new Claim(JwtRegisteredClaimNames.GivenName, firstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, lastName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("super-secret-key"));
        var signingCreds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: "Benkyoukai",
            expires: DateTime.Now.AddMinutes(30),
            claims: claims,
            signingCredentials: signingCreds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}