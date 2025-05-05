using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.DTO.Message;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Authorization;
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

    [Authorize]
    [HttpPost("SendMessage")]
    public async Task<Result> SendMessage(SendChatMessageDto dto)
    {
        await _messageService.SendMessageAsync(dto);

        return Result.Success();
    }
    [Authorize]
    [HttpPost("GetChatMessages")]
    public async Task<Result<List<GetChatMessageDto>>> GetChatMessages(long recieverId)
    {
        var messages = await _messageService.GetChatMessagesAsync(recieverId);

        return Result.Success(messages);
    }
}
