using Microsoft.AspNetCore.Mvc;
using TASK9.Models;
using TASK9.Services;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens;
using System.Text;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
namespace TASK9.Controllers;

[ApiController]

public class TokenController : ControllerBase
{
    private ILogger _logger;
    private readonly IUserRepository _UserRepository;
    private readonly ITokenService _tokenService;
    public TokenController(ILogger logger, IUserRepository UserRepository, ITokenService tokenService)
    {
        _UserRepository = UserRepository;
        _tokenService = tokenService;
        _logger = logger;
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("api/token/refresh")]
    public async Task<IActionResult> Refresh(Token token)
    {
        if (token is null)
            return BadRequest("Token is null");

        string accessToken = token.AccessToken;
        string refreshToken = token.RefreshToken;

        var principal = _tokenService.GetPrincipalFromExpiredToken(accessToken);
        var username = principal.Identity.Name;
        User user = await _UserRepository.GetUserByUsername(username);
        if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpirationDate <= DateTime.Now)
        {
            if (user.RefreshToken != refreshToken) { Console.WriteLine("Refresh token does not match"); };
            if (user.RefreshTokenExpirationDate <= DateTime.Now) { Console.WriteLine("Refresh token is expired"); };

            return BadRequest("Invalid client request");
        }


        string newAccessToken = _tokenService.GenerateAccessToken(principal.Claims);
        string newRefreshToken = _tokenService.GenerateRefreshToken();
        Console.WriteLine(newRefreshToken);

        _UserRepository.AssignRefreshTokenDat(user, newRefreshToken);
        Console.WriteLine(user.RefreshToken);
        Console.WriteLine(user.RefreshTokenExpirationDate);

        return Ok(new
        {
            accessToken = newAccessToken,
            refreshToken = newRefreshToken
        });
    }


}