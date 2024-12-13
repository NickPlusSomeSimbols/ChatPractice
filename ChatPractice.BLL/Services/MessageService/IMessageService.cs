using Ardalis.Result;

namespace ChatPractice.BLL.Services.MessageService;

public interface IMessageService
{
    Task<Result> Create(int amount);
    Task<int> GetAll();
    Task<string> GetAllFirstLetters();
}
