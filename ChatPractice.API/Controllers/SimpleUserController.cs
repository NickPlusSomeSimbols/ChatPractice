using Ardalis.Result;
using ChatPractice.BLL.Services.SimpleUserService;
using Microsoft.AspNetCore.Mvc;

namespace DocketTest_1.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SimpleUserController : ControllerBase
{
    private readonly ILogger<SimpleUserController> _logger;
    private readonly ISimpleUserService _simpleUserService;

    public SimpleUserController(ILogger<SimpleUserController> logger, ISimpleUserService simpleUserService)
    {
        _logger = logger;
        _simpleUserService = simpleUserService;
    }

    [HttpPost("[controller]/Create")]
    public async Task<Result> Create(int amount)
    {
        await _simpleUserService.Create(amount);

        return Result.Success();
    }
    [HttpPost("CreateRange")]
    public async Task<Result> CreateRange(int amount)
    {
        await _simpleUserService.CreateRange(amount);

        return Result.Success();
    }
    [HttpPost("ClearTable")]
    public Result ClearTable()
    {
        _simpleUserService.ClearTable();

        return Result.Success();
    }
    [HttpPost("GetAll")]
    public async Task<Result> GetAll()
    {
        var users = await _simpleUserService.GetAll();

        return Result.Success();
    }
}
