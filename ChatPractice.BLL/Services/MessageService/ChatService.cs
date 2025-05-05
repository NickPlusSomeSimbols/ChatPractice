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
        if(dto.ReceiverId == _userSessionService.CurrentUser.Id)
        {
            return Result.Error("You cannot send a message to yourself.");
        }

        var messageEntity = dto.MapToEntity(_userSessionService.CurrentUser.Id);

        await _chatRepository.SendMessageAsync(messageEntity);

        return Result.Success();
    }
    public async Task<Result<List<GetChatMessageDto>>> GetChatMessagesAsync(long recieverId)
    {
        var currentUserId = _userSessionService.CurrentUser.Id;

        if (currentUserId == recieverId)
        {
            return Result.Error("You cannot request your own chat.");
        }

        var messages = await _chatRepository.GetChatMessagesAsync(currentUserId, recieverId);

        var messageDtos = messages.MapToDtos(currentUserId);

        return Result.Success(messageDtos);
    }
}