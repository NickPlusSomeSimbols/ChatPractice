using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IChatService _messageService;

    public ChatController(IChatService messageService)
    {
        _messageService = messageService;
    }

    [HttpPost("SendMessage")]
    public async Task<Result> SendMessage(MessageDto dto)
    {
        await _messageService.SendMessage(dto);

        return Result.Success();
    }
}
