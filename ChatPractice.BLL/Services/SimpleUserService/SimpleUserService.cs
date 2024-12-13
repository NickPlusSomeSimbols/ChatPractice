using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatPractice.BLL.Services.SimpleUserService;

public class SimpleUserService : ISimpleUserService
{
    private readonly AppDbContext _db;
    public SimpleUserService(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result> Create(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            User user = BogusManager.GenerateRandomUser();

            if (i % 100 == 0)
            {
                Debug.WriteLine($"{i} Raws created");
            }

            await _db.Users.AddAsync(user);
        }

        await _db.SaveChangesAsync();

        return Result.Success();
    }
    public async Task<Result> CreateRange(int amount)
    {
        List<User> users = new List<User>();

        for (int i = 0; i < amount; i++)
        {
            User user = BogusManager.GenerateRandomUser();

            users.Add(user);
        }

        await _db.AddRangeAsync(users);
        await _db.SaveChangesAsync();
        return Result.Success();
    }
    public Result ClearTable()
    {
        _db.Database.ExecuteSqlRaw($"TRUNCATE TABLE public.\"Users\"");

        return Result.Success();
    }
    public async Task<Result> GetAll()
    {
        var users = await _db.Users.ToListAsync();

        return Result.Success();
    }
}
