using System.ComponentModel.DataAnnotations;

namespace ChatPractice.DTO.Dtos.Message;

public class ChatMessageDto
{
    [Required]
    public string UserName { get; set; } = default!;
    public bool isSenderMessage { get; set; }
    public string Text { get; set; } = default!;
    public DateTime SendingDate { get; set; } = default!;
}
