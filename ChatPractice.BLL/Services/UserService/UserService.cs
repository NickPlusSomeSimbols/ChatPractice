using ChatPractice.DAL;

namespace ChatPractice.BLL.Services.UserService;

public class UserService : IUserService
{
    private readonly AppDbContext _db;
    public UserService(AppDbContext db)
    {
        _db = db;
    }
}
