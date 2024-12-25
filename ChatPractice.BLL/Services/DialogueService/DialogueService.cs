using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatPractice.BLL.Services.ConversationService;

public class DialogueService : IDialogueService
{
    private readonly AppDbContext _db;
    private readonly IUserSessionService _userSession;
    public DialogueService(AppDbContext db, IUserSessionService userSession)
    {
        _db = db;
        _userSession = userSession;
    }
    
    public async Task<Result<List<Dialogue>>> GetAllDialogues()
    {
        return Result.Success();
        // var conversations = _db.Conversations.Where(x=>x.Users). 
    }

    public async Task<Result<Dialogue>> CreateDialogue(long recieverId)
    {
        var currentUser = _userSession.CurrentUser;

        if (currentUser == null)
        {
            throw new ArgumentNullException(nameof(currentUser));
        }

        var receiverUser = await _db.Users.FirstOrDefaultAsync(x => x.Id == recieverId);
        
        if (receiverUser == null)
        {
            throw new ArgumentNullException(nameof(receiverUser));
        }

        var dialogue = new Dialogue()
        {
            UserOne = currentUser,
            UserTwo = receiverUser,
        };

        _db.Dialogues.Add(dialogue);
        await _db.SaveChangesAsync();

        return Result.Success(dialogue);
    }
}
