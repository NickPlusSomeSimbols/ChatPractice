using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

namespace DocketTest_1.Controllers;
[ApiController]
[Route("api")]
public class MessageController : ControllerBase
{
    private readonly ILogger<MessageController> _logger;
    private readonly IMessageService _messageService;

    public MessageController(ILogger<MessageController> logger, IMessageService messageService)
    {
        _logger = logger;
        _messageService = messageService;
    }

    [HttpPost("[controller]/Create")]
    public async Task<Result> Create(int amount)
    {
        await _messageService.Create(amount);

        return Result.Success();
    }
}
