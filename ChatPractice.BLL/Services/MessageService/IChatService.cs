using Ardalis.Result;
using ChatPractice.DTO.Message;

namespace ChatPractice.BLL.Services.MessageService;

public interface IChatService
{
    Task<Result> SendMessage(MessageDto dto);
}
