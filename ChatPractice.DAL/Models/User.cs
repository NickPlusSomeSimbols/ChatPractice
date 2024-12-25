using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class User : BaseModel
{
    public User()
    {
        Dialogues = new HashSet<Dialogue>();
    }
    public string Email { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public ICollection<Dialogue> Dialogues { get; set; } 
}

