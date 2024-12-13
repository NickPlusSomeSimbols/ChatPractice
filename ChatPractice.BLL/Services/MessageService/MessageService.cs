using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using System.Diagnostics;

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
}
