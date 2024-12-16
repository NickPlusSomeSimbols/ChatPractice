using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace ChatPractice.BLL.Services.MessageService;

public class MessageService : IMessageService
{
    private readonly AppDbContext _db;
    public MessageService(AppDbContext db)
    {
        _db = db;
    }

    public Task<Result> SendMessage(long userId)
    {
        throw new NotImplementedException();
    }
}
