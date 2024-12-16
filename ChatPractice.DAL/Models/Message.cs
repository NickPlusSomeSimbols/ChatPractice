using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class Message : BaseModel
{
    public string Text { get; set; } = default!;
    public DateTime PostDate { get; set; }
    public long UserId { get; set; }
    public long ConversationId { get; set; }
}
