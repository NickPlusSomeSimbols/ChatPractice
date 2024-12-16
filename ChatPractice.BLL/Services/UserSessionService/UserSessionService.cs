using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO;
using ChatPractice.DTO.User;
using ChatPractice.DTO.UserSession;
using CryptoHelper;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using static System.Net.Mime.MediaTypeNames;

namespace ChatPractice.BLL.Services.UserSessionService;

public class UserSessionService : IUserSessionService
{
    private readonly AppDbContext _db;
    public UserSessionService(AppDbContext db)
    {
        _db = db;
    }
    public User CurrentUser { get; set; }

    User IUserSessionService.CurrentUser { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

    public async Task<Result<string>> Register(RegisterDto dto)
    {
        User? user = await _db.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user != null)
        {
            return Result.Success("User with such email already exists");
        }

        user = new User
        {
            Email = dto.Email,
            Name = dto.Name,
            PasswordHash = Crypto.HashPassword(dto.Password) // TODO setup validation
        };

        _db.Users.Add(user);
        await _db.SaveChangesAsync();

        return Result.Success("User created successfully");
    }

    public async Task<Result<string>> Login(LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null || !Crypto.VerifyHashedPassword(user.PasswordHash, dto.Password))
        {
            return Result.Success("Authentication failed");
        }

        var token = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

        var session = new UserSession
        {
            Token = token,
            UserId = user.Id,
        };

        _db.UserSessions.Add(session);

        await _db.SaveChangesAsync();

        var userSession = await _db.UserSessions.FirstOrDefaultAsync(x => x.Id == session.Id);
        
        return Result.Success(userSession!.Token);
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