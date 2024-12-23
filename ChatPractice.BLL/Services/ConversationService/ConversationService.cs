using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.DAL;

namespace ChatPractice.BLL.Services.ConversationService;

public class ConversationService : IConversationService
{
    private readonly AppDbContext _db;
    public ConversationService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<List<Conversation>>> GetAllConversations(long userId)
    {
        throw new NotImplementedException();
    }
}
