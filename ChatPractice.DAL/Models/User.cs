using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class User : BaseModel
{
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public ICollection<Conversation>? Conversations { get; set; }
}

