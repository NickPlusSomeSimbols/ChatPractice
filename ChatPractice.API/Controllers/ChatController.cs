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
        var result = await _messageService.SendMessageAsync(dto);

        return result;
    }
    [Authorize]
    [HttpGet("GetChatMessages")]
    public async Task<Result<List<GetChatMessageDto>>> GetChatMessages(long recieverId)
    {
        var result = await _messageService.GetChatMessagesAsync(recieverId);

        return result;
    }
}
