using Ardalis.Result;
using ChatPractice.BLL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace DocketTest_1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly IUserService _userService;

    public UserController(ILogger<UserController> logger, IUserService simpleUserService)
    {
        _logger = logger;
        _userService = simpleUserService;
    }

    [HttpPost("GetAllDialogues")]
    public async Task<Result> GetAllDialogues()
    {
        await _userService.GetAllDialogues();

        return Result.Success();
    }
}
