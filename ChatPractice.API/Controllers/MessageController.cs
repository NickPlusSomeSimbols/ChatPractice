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

    [HttpPost("SendMessage")]
    public async Task<Result> SendMessage(long recieverId)
    {
        await _messageService.SendMessage(recieverId);

        return Result.Success();
    }
}
