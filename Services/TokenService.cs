using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
namespace TASK9.Services;



public class TokenService : ITokenService
{
    public string GenerateAccessToken(IEnumerable<Claim> userClaim)
    {
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sfsdfsdfdsfsdfsdfsdfsddfaefwewmjcndsnsdjfsdfsdbnhsbvbhcxi"));
        SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


        JwtSecurityToken token = new JwtSecurityToken(

        issuer: "http://localhost:5227",
        audience: "http://localhost:5227",
        claims: userClaim,
        expires: DateTime.Now.AddSeconds(30),
        signingCredentials: creds
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return tokenString;
    }

    public string GenerateRefreshToken()
    {

        return Guid.NewGuid().ToString();

    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = false, //you might want to validate the audience and issuer depending on your use case
            ValidateIssuer = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sfsdfsdfdsfsdfsdfsdfsddfaefwewmjcndsnsdjfsdfsdbnhsbvbhcxi")),
            ValidateLifetime = false //here we are saying that we don't care about the token's expiration date
        };

        Console.WriteLine("Getting principal");


        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        Console.WriteLine("Validating principal...");
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
        Console.WriteLine("Validating jwtSecurityToken...");
        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            throw new SecurityTokenException("Invalid token");

        return principal;
    }
}