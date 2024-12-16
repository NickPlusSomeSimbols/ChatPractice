using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMessageService _messageService;

    public MessageController(IMessageService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("Create")]
    public async Task<Result> Create(long userId)
    {
        await _messageService.SendMessage(userId);

        return Result.Success();
    }
}
