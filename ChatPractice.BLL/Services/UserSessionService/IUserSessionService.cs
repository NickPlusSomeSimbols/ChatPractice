﻿using Ardalis.Result;
using ChatPractice.DAL.Models;
using ChatPractice.DTO;
using ChatPractice.DTO.User;
using ChatPractice.DTO.UserSession;

namespace ChatPractice.BLL.Services.UserSessionService;

public interface IUserSessionService
{
    public Task<Result<string>> Register(RegisterDto dto);
    public Task<Result<string>> Login(LoginDto dto);
    public Task<Result> Logout();
    public Task<Result<UserDto>> GetByToken(string token);
    public User CurrentUser { get; set; }
}
