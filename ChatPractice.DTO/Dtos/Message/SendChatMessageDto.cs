using System.ComponentModel.DataAnnotations;

namespace ChatPractice.DTO.Dtos.Message;

public class SendChatMessageDto
{
    [Required]
    public long ReceiverId { get; set; }
    [Required]
    public string Text { get; set; } = default!;
}
