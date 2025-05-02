using Ardalis.Result;
using ChatPractice.BLL.Services.MessageService;
using ChatPractice.DTO.Message;
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
    public async Task<Result> SendMessage(SentMessageDto dto)
    {
        await _messageService.SendMessageAsync(dto);

        return Result.Success();
    }
    [HttpPost("GetChatMessages")]
    public async Task<Result<List<QueriedChatMessageDto>>> GetChatMessages(long accountId, long recieverId)
    {
        var messages = await _messageService.GetChatMessagesAsync(accountId, recieverId);

        return Result.Success(messages);
    }
}
