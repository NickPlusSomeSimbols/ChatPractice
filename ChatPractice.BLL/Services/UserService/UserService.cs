using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.DAL;
using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatPractice.BLL.Services.UserService;

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    public UserService(AppDbContext db)
    {
        _db = db;
    }
}
