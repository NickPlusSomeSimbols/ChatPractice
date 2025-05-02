using ChatPractice.DTO.UserSession;

namespace ChatPractice.DTO.Message;

public class SendChatMessageDto
{
    public long ReceieverId { get; set; } = default!;
    public string Text { get; set; } = default!;
}
