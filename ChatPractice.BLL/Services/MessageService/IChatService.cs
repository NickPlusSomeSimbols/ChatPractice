using Ardalis.Result;
using ChatPractice.DTO.Dtos.Message;

namespace ChatPractice.BLL.Services.MessageService;

public interface IChatService
{
    Task<Result> SendMessageAsync(SendChatMessageDto dto);
    Task<Result<List<ChatMessageDto>>> GetChatMessagesAsync(long recieverId);
}
