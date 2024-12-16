using Ardalis.Result;
using ChatPractice.BLL.Services.UserService;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService simpleUserService)
    {
        _userService = simpleUserService;
    }
}
