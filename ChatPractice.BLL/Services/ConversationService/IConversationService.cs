using Ardalis.Result;
using BelvedereFood.DAL.Models;

namespace ChatPractice.BLL.Services.ConversationService;

public interface IConversationService
{
    Task<Result<List<Dialogue>>> GetAllConversations(); // TODO change to DTO
    Task<Result> CreateConversation(long destinationUserId);
}
