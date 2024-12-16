using Ardalis.Result;
using ChatPractice.DTO;
using ChatPractice.DTO.UserSession;

namespace ChatPractice.BLL.Services.SessionService;

public interface IUserSessionService
{
    public Task<Result> Register(RegisterDto dto);
    public Task<Result<string>> Login(LoginDto dto);
    public Task<Result> Logout();
}
