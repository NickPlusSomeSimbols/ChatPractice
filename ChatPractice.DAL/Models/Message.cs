using BelvedereFood.DAL.Models;

namespace ChatPractice.DAL.Models;
public class Message : BaseModel
{
    public string Text { get; set; } = default!;
    public DateTime PostDate { get; set; }
    public long SenderId { get; set; }

    public Dialogue? Dialogue { get; set; }
    public long? DialogueId { get; set; }
}
