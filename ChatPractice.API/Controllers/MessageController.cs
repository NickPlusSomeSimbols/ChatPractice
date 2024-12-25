using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.DTO.UserSession;
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
    public async Task<Result> SendMessage(SendMessageDto dto)
    {
        await _messageService.SendMessage(dto);

        return Result.Success();
    }
}
