using ChatPractice.DAL.Models;
using ChatPractice.DTO.Dtos.Message;
using ChatPractice.DTO.ViewModels;
using Riok.Mapperly.Abstractions;

namespace ChatPractice.BLL.Mappers;

[Mapper]
public static partial class ChatMessageMapper
{
    public static ChatMessage MapToEntity(this SendChatMessageDto message, long accountId)
    {
        return new ChatMessage
        {
            SenderId = accountId,
            ReceieverId = message.ReceiverId,
            Text = message.Text,
            SendingDate = DateTime.UtcNow
        };
    }

    public static List<ChatMessageDto> MapToDtos(this List<ChatMessage> messages, long accountId)
    {
        var messageDtos = new List<ChatMessageDto>();

        foreach (var message in messages)
        {
            messageDtos.Add(new ChatMessageDto
            {
                isSenderMessage = accountId == message.SenderId,
                Text = message.Text,
                SendingDate = message.SendingDate,
            });
        }

        return messageDtos;
    }
}