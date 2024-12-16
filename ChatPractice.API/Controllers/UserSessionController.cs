using Ardalis.Result;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.BLL.Services.UserService;
using ChatPractice.DTO;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserSessionController : ControllerBase
{
    private readonly IUserSessionService _userSessionService;

    public UserSessionController(IUserSessionService userSessionService)
    {
        _userSessionService = userSessionService;
    }

    [HttpPost("Register")]
    public async Task<Result<string>> Register(RegisterDto dto)
    {
        return await _userSessionService.Register(dto);
    }

    [HttpPost("Login")]
    public async Task<Result<string>> Login(LoginDto dto)
    {
        return await _userSessionService.Login(dto);
    }

    [HttpPost("Logout")]
    public async Task<Result> Logout()
    {
        await _userSessionService.Logout();

        return Result.Success();
    }
}
