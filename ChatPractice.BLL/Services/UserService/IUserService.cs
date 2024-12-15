using Ardalis.Result;
using BelvedereFood.DAL.Models;

namespace ChatPractice.BLL.Services.UserService;

public interface IUserService
{
    Task<Result<List<Conversation>>> GetAllDialogues(); // TODO change to DTO
}
