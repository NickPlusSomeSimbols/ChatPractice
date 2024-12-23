using Ardalis.Result;
using ChatPractice.DAL;

namespace ChatPractice.BLL.Services.MessageService;

public class MessageService : IMessageService
{
    private readonly AppDbContext _db;
    public MessageService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result> SendMessage(long recieverId)
    {
        throw new NotImplementedException();
    }
}
