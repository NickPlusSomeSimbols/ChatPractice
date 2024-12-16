using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO;
using ChatPractice.DTO.UserSession;
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
    public Task<Result> Register(RegisterDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Result<string>> LogIn(LoginDto dto)
    {
        throw new NotImplementedException();
    }

    public Task<Result> LogOut()
    {
        throw new NotImplementedException();
    }

}