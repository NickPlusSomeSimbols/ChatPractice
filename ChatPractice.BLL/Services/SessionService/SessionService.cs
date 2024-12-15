using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatPractice.BLL.Services.SessionService;

public class SessionService : ISessionService
{
    private readonly AppDbContext _db;
    public SessionService(AppDbContext db)
    {
        _db = db;
    }

    public Task<Result<string>> LogIn()
    {
        throw new NotImplementedException();
    }

    public Task<Result> LogOut()
    {
        throw new NotImplementedException();
    }

    public Task<Result> Register()
    {
        throw new NotImplementedException();
    }
}