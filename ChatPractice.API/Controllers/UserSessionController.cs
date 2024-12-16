using Ardalis.Result;
using ChatPractice.BLL.Services.SessionService;
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
    public async Task<Result> Register(RegisterDto dto)
    {
        await _userSessionService.Register(dto);

        return Result.Success();
    }

    [HttpPost("Login")]
    public async Task<Result> Login(LoginDto dto)
    {
        await _userSessionService.Login(dto);

        return Result.Success();
    }

    [HttpPost("Logout")]
    public async Task<Result> Logout()
    {
        await _userSessionService.Logout();

        return Result.Success();
    }
}
