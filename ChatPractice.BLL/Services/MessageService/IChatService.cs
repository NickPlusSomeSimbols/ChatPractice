using Ardalis.Result;
using ChatPractice.DTO.Message;

namespace ChatPractice.BLL.Services.MessageService;

public interface IChatService
{
    Task<Result> SendMessageAsync(SendChatMessageDto dto);
    Task<Result<List<GetChatMessageDto>>> GetChatMessagesAsync(long recieverId);
}
