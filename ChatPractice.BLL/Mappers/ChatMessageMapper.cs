using ChatPractice.DAL.Models;
using ChatPractice.DTO.Message;
using ChatPractice.DTO.User;
using Riok.Mapperly.Abstractions;
using System.Security.Principal;

namespace ChatPractice.BLL.Mappers;

[Mapper]
public static partial class ChatMessageMapper
{
    public static SentChatMessageDto MapToDto(this ChatMessage message)
    {
        return new SentChatMessageDto
        {
            SenderId = message.SenderId,
            ReceieverId = message.ReceieverId,
            Text = message.Text,
            SendingDate = message.SendingDate
        };
    }

    public static List<QueriedChatMessageDto> MapToDtos(this List<ChatMessage> messages, long accountId)
    {
        var messageDtos = new List<QueriedChatMessageDto>();

        foreach (var message in messages)
        {
            messageDtos.Add(new QueriedChatMessageDto
            {
                isSenderMessage = accountId == message.SenderId,
                Text = message.Text,
                SendingDate = message.SendingDate,
            });
        }

        return messageDtos;
    }
}