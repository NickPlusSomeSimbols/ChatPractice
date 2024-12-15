using ChatPractice.DAL.Models;

namespace BelvedereFood.DAL.Models;

public class Conversation : BaseModel
{
    public IEnumerable<User> Users { get; set; } = default!;
    public IEnumerable<Message> Messages { get; set; } = default!;
}