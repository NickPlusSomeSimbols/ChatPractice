using Ardalis.Result;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.BLL.Services.UserService;
using ChatPractice.DTO;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ChatPractice.BLL.Attributes;

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

    [SkipPermissionCheck]
    [HttpPost("Register")]
    public async Task<Result<string>> Register(RegisterDto dto)
    {
        return await _userSessionService.Register(dto);
    }

    [SkipPermissionCheck]
    [HttpPost("Login")]
    public async Task<Result<string>> Login(LoginDto dto)
    {
        return await _userSessionService.Login(dto);
    }

    [HttpPost("Logout")]
    public async Task<Result> Logout()
    {
        return await _userSessionService.Logout();
    }
}
