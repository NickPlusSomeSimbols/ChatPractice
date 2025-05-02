using Ardalis.Result;
using ChatPractice.BLL.Mappers;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DAL.Repository;
using ChatPractice.DTO.Message;
using Microsoft.EntityFrameworkCore;

namespace ChatPractice.BLL.Services.MessageService;

public class ChatService : IChatService
{
    private readonly IUserSessionService _userSessionService;
    private readonly IChatRepository _chatRepository;
    public ChatService(IUserSessionService userSessionService, IChatRepository chatRepository)
    {
        _userSessionService = userSessionService;
        _chatRepository = chatRepository;
    }

    public async Task<Result> SendMessageAsync(SentChatMessageDto dto)
    {
        var message = new ChatMessage
        {
            SenderId = 0, //_userSessionService.CurrentUser.Id,
            ReceieverId = dto.ReceieverId,
            Text = dto.Text,
            SendingDate = DateTime.UtcNow
        };

        await _chatRepository.SendMessageAsync(message);

        return Result.Success();
    }
    public async Task<Result<List<QueriedChatMessageDto>>> GetChatMessagesAsync(long accountId, long recieverId)
    {
        var messages = await _chatRepository.GetChatMessagesAsync(accountId, recieverId);

        var messageDtos = messages.MapToDtos(accountId);

        return Result.Success(messageDtos);
    }
}