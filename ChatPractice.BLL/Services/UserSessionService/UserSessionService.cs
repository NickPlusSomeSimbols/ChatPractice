using Ardalis.Result;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO;
using ChatPractice.DTO.User;
using ChatPractice.DTO.UserSession;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatPractice.BLL.Services.UserSessionService;

public class UserSessionService : IUserSessionService
{
    private readonly AppDbContext _db;
    public UserSessionService(AppDbContext db)
    {
        _db = db;
    }
    public User CurrentUser;

    User IUserSessionService.CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<Result> Register(RegisterDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<string>> Login(LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x=>x.Email == dto.Email);

        if (user == null)
        {
            return Result.Success("Authentication failed");
        }

        return Result.Success();
    }

    public Task<Result> Logout()
    {
        throw new NotImplementedException();
    }

    public Task<UserDto> GetByToken(string token)
    {
        throw new NotImplementedException();
    }
}