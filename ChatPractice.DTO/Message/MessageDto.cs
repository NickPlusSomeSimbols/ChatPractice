using ChatPractice.DTO.UserSession;

namespace ChatPractice.DTO.Message;

public class MessageDto
{
    public string ReceiverId { get; set; } = default!;
    public string Text { get; set; } = default!;
 }
