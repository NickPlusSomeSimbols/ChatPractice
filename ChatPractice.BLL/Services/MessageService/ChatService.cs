using Ardalis.Result;
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

    public async Task<Result> SendMessageAsync(SentMessageDto dto)
    {
        var message = new ChatMessage
        {
            SenderId = 0, //_userSessionService.CurrentUser.Id,
            ReceiverId = dto.ReceiverId,
            Text = dto.Text,
            SendingDate = DateTime.UtcNow
        };

        await _chatRepository.SendMessageAsync(message);

        return Result.Success();
    }
    public async Task<Result<List<QueriedChatMessageDto>>> GetChatMessagesAsync(long accountId, long recieverId)
    {
        var messages = await _chatRepository.GetChatMessagesAsync(accountId, recieverId);

        // make proper mapping
        var messageDtos = messages.Select(x => new QueriedChatMessageDto
        {
            isSenderMessage = x.SenderId == accountId,
            Text = x.Text,
            SendingDate = x.SendingDate,
        }).ToList();

        return Result.Success(messageDtos);
    }
}