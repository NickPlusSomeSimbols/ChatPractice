using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatPractice.BLL.Services.ConversationService;

public class ConversationService : IConversationService
{
    private readonly AppDbContext _db;
    private readonly IUserSessionService _userSession;
    public ConversationService(AppDbContext db, IUserSessionService userSession)
    {
        _db = db;
        _userSession = userSession;
    }
    
    public async Task<Result<List<Dialogue>>> GetAllConversations()
    {
        return Result.Success();
        // var conversations = _db.Conversations.Where(x=>x.Users). 
    }

    public async Task<Result> CreateConversation(long destinationUserId)
    {
        var currentUser = _userSession.CurrentUser;

        if (currentUser == null)
        {
            throw new ArgumentNullException(nameof(currentUser));
        }

        var destinationUser = await _db.Users.FirstOrDefaultAsync(x => x.Id == destinationUserId);
        
        if (destinationUser == null)
        {
            throw new ArgumentNullException(nameof(destinationUser));
        }

        var conversation = new Dialogue()
        {
            UserOne = currentUser,
            UserTwo = destinationUser,
        };

        _db.Conversations.Add(conversation);
        await _db.SaveChangesAsync();

        return Result.Success();
    }
}
