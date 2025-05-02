using ChatPractice.DTO.UserSession;

namespace ChatPractice.DTO.Message;

public class SentChatMessageDto
{
    public long SenderId { get; set; } = default!;
    public long ReceieverId { get; set; } = default!;
    public string Text { get; set; } = default!;
    public DateTime SendingDate { get; set; } = default!;
}
