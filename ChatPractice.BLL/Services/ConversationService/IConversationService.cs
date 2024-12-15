using Ardalis.Result;
using BelvedereFood.DAL.Models;

namespace ChatPractice.BLL.Services.ConversationService;

public interface IConversationService
{
    Task<Result<List<Conversation>>> ListConversations(); // TODO change to DTO
}
