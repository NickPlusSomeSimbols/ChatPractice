﻿using Ardalis.Result;
using ChatPractice.BLL.Mappers;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using ChatPractice.DTO.Dtos.User;
using ChatPractice.DTO.Dtos.UserSession;
using CryptoHelper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

namespace ChatPractice.BLL.Services.UserSessionService;

public class UserSessionService : IUserSessionService
{
    private User _currentUser;
    private readonly AppDbContext _db;
    private readonly IHttpContextAccessor _httpContext;
    public UserSessionService(AppDbContext db, IHttpContextAccessor httpContext)
    {
        _db = db;
        _httpContext = httpContext;
    }

    public User CurrentUser
    {
        get
        {
            return _currentUser;
        }
        set
        {
            _currentUser = value ?? throw new ArgumentNullException(nameof(value), "Current user cannot be null.");
        }
    }

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

        return Result.Success($"User {user.Id} created successfully");
    }

    public async Task<Result<string>> Login(LoginDto dto)
    {
        var user = await _db.Users.FirstOrDefaultAsync(x => x.Email == dto.Email);

        if (user == null)
        {
            return Result.NotFound("User not found");
        }

        if (!Crypto.VerifyHashedPassword(user.PasswordHash, dto.Password))
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

    public async Task<Result> Logout()
    {
        if (_httpContext.HttpContext == null)
        {
            throw new Exception("HttpContext is null");
        }

        _httpContext.HttpContext.Request.Headers.TryGetValue(HeaderNames.Authorization, out var token);

        var session = await _db.UserSessions.FirstOrDefaultAsync(x => x.Token == token.ToString());

        if (session != null)
        {
            session.IsExpired = true;
            session.IsDeleted = true;

            await _db.SaveChangesAsync();
        }

        return Result.Success();
    }

    public async Task<UserDto> GetByToken(string token)
    {
        var session = await _db.UserSessions.Select(x => new { x.UserId, x.Token }).Where(x => x.Token == token).FirstOrDefaultAsync();

        if (session == null)
        {
            throw new Exception("Session not found");
        }

        var user = await _db.Users.FirstOrDefaultAsync(x => x.Id == session.UserId);

        if (user == null)
        {
            throw new Exception("User not found");
        }

        return user.MapToDto();
    }
}