using Ardalis.Result;

namespace ChatPractice.BLL.Services.SessionService;

public interface ISessionService
{
    public Task<Result> Register();
    public Task<Result<string>> LogIn();
    public Task<Result> LogOut();
}
