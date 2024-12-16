using Ardalis.Result;
using BelvedereFood.DAL.Models;

namespace ChatPractice.BLL.Services.ConversationService;

public interface IConversationService
{
    Task<Result<List<Conversation>>> GetAllConversations(long userId); // TODO change to DTO
}
