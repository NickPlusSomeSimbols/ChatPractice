using ChatPractice.DTO.UserSession;

namespace ChatPractice.DTO.Message;

public class MessageDto
{
    public string Text { get; set; } = default!;
    public DateTime PostDate { get; set; }
    public long SenderId { get; set; }

    public DialogueDto? Dialogue { get; set; }
    public long? DialogueId { get; set; }
}
