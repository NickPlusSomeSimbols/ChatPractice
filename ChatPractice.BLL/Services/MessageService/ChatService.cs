using Ardalis.Result;
using ChatPractice.BLL.Services.UserSessionService;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO.Message;

namespace ChatPractice.BLL.Services.MessageService;

public class ChatService : IChatService
{
    private readonly AppDbContext _db;
    private readonly IUserSessionService _userSessionService;
    public ChatService(AppDbContext db, IUserSessionService userSessionService)
    {
        _db = db;
        _userSessionService = userSessionService;
    }

    public async Task<Result> SendMessage(MessageDto dto)
    {
        var message = new ChatMessage
        {
            SenderId = null, //_userSessionService.CurrentUser.Id,
            ReceiverId = dto.ReceiverId,
            Text = dto.Text,
            SendingDate = DateTime.UtcNow
        };



        return Result.Success();
    }
}
