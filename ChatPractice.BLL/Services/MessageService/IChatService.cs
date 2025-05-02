using Ardalis.Result;
using ChatPractice.DTO.Message;

namespace ChatPractice.BLL.Services.MessageService;

public interface IChatService
{
    Task<Result> SendMessageAsync(SentMessageDto dto);
    Task<Result<List<QueriedChatMessageDto>>> GetChatMessagesAsync(long accountId, long recieverId);
}
