using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Common.Entity;
using Microsoft.IdentityModel.Tokens;

namespace api.Services;

public class TokenService
{
    public string CreateToken(User user)
    {
        Claim[] claims =
        {
            new Claim("loggedUserId", user.Id.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("parola123parola123parola123parola123"));
        var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        JwtSecurityToken token = new JwtSecurityToken(
            issuer: "LOTMWikiApi",
            audience: "front-end",
            claims: claims,
            expires: DateTime.Now.AddMinutes(2),
            signingCredentials: cred);
        
        string tokenData = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenData;
    }
}