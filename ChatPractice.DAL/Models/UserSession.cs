using ChatPractice.DAL.Models;

namespace BelvedereFood.DAL.Models;

public class UserSession : BaseModel
{
    public long UserId { get; set; }
    public string Token { get; set; } = default!;
    public bool IsExpired { get; set; }

    public User User { get; set; } = default!;
}