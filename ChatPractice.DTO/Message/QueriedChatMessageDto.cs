using ChatPractice.DTO.UserSession;

namespace ChatPractice.DTO.Message;

public class QueriedChatMessageDto
{
    public bool isSenderMessage { get; set; }
    public string Text { get; set; } = default!;
    public DateTime SendingDate { get; set; } = default!;
}
