using ChatPractice.DAL.Models;
using ChatPractice.DTO.Message;
using ChatPractice.DTO.User;
using Riok.Mapperly.Abstractions;
using System.Security.Principal;

namespace ChatPractice.BLL.Mappers;

[Mapper]
public static partial class ChatMessageMapper
{
    public static ChatMessage MapToEntity(this SendChatMessageDto message, long accountId)
    {
        return new ChatMessage
        {
            SenderId = accountId,
            ReceieverId = message.ReceieverId,
            Text = message.Text,
            SendingDate = DateTime.UtcNow
        };
    }

    public static List<GetChatMessageDto> MapToDtos(this List<ChatMessage> messages, long accountId)
    {
        var messageDtos = new List<GetChatMessageDto>();

        foreach (var message in messages)
        {
            messageDtos.Add(new GetChatMessageDto
            {
                isSenderMessage = accountId == message.SenderId,
                Text = message.Text,
                SendingDate = message.SendingDate,
            });
        }

        return messageDtos;
    }
}