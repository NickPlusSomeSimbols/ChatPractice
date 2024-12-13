using Ardalis.Result;

namespace ChatPractice.BLL.Services.SimpleUserService;

public interface ISimpleUserService
{
    Task<Result> Create(int amount);
    Task<Result> CreateRange(int amount);
    Result ClearTable();
    Task<Result> GetAll();
}
