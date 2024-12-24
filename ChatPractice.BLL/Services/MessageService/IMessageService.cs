using Ardalis.Result;

namespace ChatPractice.BLL.Services.MessageService;

public interface IMessageService
{
    Task<Result> SendMessage(long receiverId);
}
