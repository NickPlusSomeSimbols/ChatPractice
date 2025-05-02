using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class ChatMessage : BaseModel
{
    public long SenderId { get; set; } = default!;
    public long ReceieverId { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime SendingDate { get; set; }
}
