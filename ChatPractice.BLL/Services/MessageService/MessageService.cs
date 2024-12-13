using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Text;

namespace ChatPractice.BLL.Services.MessageService;


public class MessageService : IMessageService
{
    private readonly AppDbContext _AppDbContext;
    public MessageService(AppDbContext AppDbContext)
    {
        _AppDbContext = AppDbContext;
    }

    public async Task<Result> Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            Message message = BogusManager.GenerateRandomMessage();

            if (i % 100 == 0)
            {
                Debug.WriteLine($"{i} Raws created");
            }

            await _AppDbContext.Messages.AddAsync(message);
        }

        await _AppDbContext.SaveChangesAsync();

        return Result.Success();
    }
    public async Task<int> GetAll()
    {
        var messages = await _AppDbContext.Messages.ToListAsync();

        return messages.Count;
    }
    public async Task<string> GetAllFirstLetters()
    {
        var messages = await _AppDbContext.Messages.ToListAsync();

        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append(string.Empty);
        foreach (var message in messages)
        {
            stringBuilder.Append(message.Text[0]).Append(' ');
        }

        return stringBuilder.ToString();
    }
}
