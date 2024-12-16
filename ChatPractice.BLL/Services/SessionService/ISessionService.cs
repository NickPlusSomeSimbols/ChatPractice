using Ardalis.Result;
using ChatPractice.DTO;
using ChatPractice.DTO.UserSession;

namespace ChatPractice.BLL.Services.SessionService;

public interface ISessionService
{
    public Task<Result> Register(RegisterDto dto);
    public Task<Result<string>> LogIn(LoginDto dto);
    public Task<Result> LogOut();
}
