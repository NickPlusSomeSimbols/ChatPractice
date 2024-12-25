using Ardalis.Result;
using ChatPractice.BLL.Services.ConversationService;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ChatPractice.BLL.Services.MessageService;

public class MessageService : IMessageService
{
    private readonly AppDbContext _db;
    private readonly IUserSessionService _userSession;
    private readonly IDialogueService _dialogueService;
    public MessageService(AppDbContext db, IUserSessionService userSession, IDialogueService dialogueService)
    {
        _db = db;
        _userSession = userSession;
        _dialogueService = dialogueService;
    }

    public async Task<Result> SendMessage(SendMessageDto dto)
    {
        var sender = _userSession.CurrentUser;
        var receiver = await _db.Users.FirstOrDefaultAsync(x => x.Id == dto.receiverId);

        if (receiver == null)
        {
            throw new ArgumentNullException(nameof(receiver));
        }

        var dialogue = sender.Dialogues.FirstOrDefault(x => x.UserOneId == receiver.Id || x.UserTwoId == receiver.Id);

        if (dialogue == null)
        {
            dialogue = (await _dialogueService.CreateDialogue(receiver.Id)).Value;
        }

        var message = new Message()
        {
            Text = dto.Text,
            DialogueId = dialogue.Id,
            PostDate = DateTime.UtcNow,
            SenderId = sender.Id,
        };

        return Result.Success(); 
    }
}
