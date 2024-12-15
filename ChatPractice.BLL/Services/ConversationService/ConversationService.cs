using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.DAL;

namespace ChatPractice.BLL.Services.ConversationService;


public class ConversationService : IConversationService
{
    private readonly AppDbContext _AppDbContext;
    public ConversationService(AppDbContext AppDbContext)
    {
        _AppDbContext = AppDbContext;
    }

    public Task<Result<List<Conversation>>> ListConversations()
    {
        throw new NotImplementedException();
    }
}
