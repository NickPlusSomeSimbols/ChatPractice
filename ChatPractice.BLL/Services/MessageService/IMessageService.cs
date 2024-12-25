using Ardalis.Result;
using ChatPractice.DTO.UserSession;

namespace ChatPractice.BLL.Services.MessageService;

public interface IMessageService
{
    Task<Result> SendMessage(SendMessageDto dto);
}
