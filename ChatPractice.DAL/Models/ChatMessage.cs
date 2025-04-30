using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class ChatMessage : BaseModel
{
    public string SenderId { get; set; } = default!;
    public string ReceiverId { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime SendingDate { get; set; }
}
