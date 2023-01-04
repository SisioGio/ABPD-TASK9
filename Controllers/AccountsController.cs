using Microsoft.AspNetCore.Mvc;
using TASK9.Models;
using TASK9.Services;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace TASK9.Controllers;

[ApiController]

public class AccountsController : ControllerBase
{
    private ILogger _logger;
    private readonly IUserRepository _UserRepository;
    private readonly ITokenService _tokenService;
    public AccountsController(ILogger logger, IUserRepository UserRepository, ITokenService tokenService)
    {
        _UserRepository = UserRepository;
        _tokenService = tokenService;
        _logger = logger;
    }

    [AllowAnonymous]
    [Route("api/user/login")]
    [HttpPost()]
    public async Task<IActionResult> Login(UserDTO form)
    {
        if (!_UserRepository.CheckIfUserExists(form))
        {
            return Unauthorized("User does not exists in database, please create a new one");
        }

        User user = await _UserRepository.Login(form);
        if (user == null)
        {
            return BadRequest("Password not correct");
        }
        Claim[] userClaim = new[] {
            new Claim(ClaimTypes.Name,form.Username),
            new Claim(ClaimTypes.Role,"user")
        };



        string AccessToken = _tokenService.GenerateAccessToken(userClaim);
        string refreshToken = _tokenService.GenerateRefreshToken();

        await _UserRepository.AssignRefreshTokenDat(user, refreshToken);



        return Ok(new
        {
            accessToken = AccessToken,
            refreshToken = refreshToken
        }
        );
    }



    [AllowAnonymous]
    [Route("api/user/register")]
    [HttpPost()]
    public async Task<IActionResult> Register(UserDTO form)
    {
        if (_UserRepository.CheckIfUserExists(form))
        {
            return BadRequest("User already exists");
        }

        User user = await _UserRepository.AddUser(form);

        return Ok(user);

    }



    [Authorize]
    [Route("api/user/secret")]
    [HttpPost()]
    public IActionResult Secret()
    {
        return Ok("Secret data!");
    }



}