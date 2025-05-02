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

    public async Task<Result> SendMessageAsync(SendChatMessageDto dto)
    {
        var messageEntity = dto.MapToEntity(_userSessionService.CurrentUser.Id);

        await _chatRepository.SendMessageAsync(messageEntity);

        return Result.Success();
    }
    public async Task<Result<List<GetChatMessageDto>>> GetChatMessagesAsync(long accountId, long recieverId)
    {
        var messages = await _chatRepository.GetChatMessagesAsync(accountId, recieverId);

        var messageDtos = messages.MapToDtos(accountId);

        return Result.Success(messageDtos);
    }
}