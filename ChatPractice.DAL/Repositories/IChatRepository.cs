using ChatPractice.DAL.Models;

namespace ChatPractice.DAL.Repository;
public interface IChatRepository
{
    Task SendMessageAsync(ChatMessage message);
    Task<List<ChatMessage>> GetChatMessagesAsync(long accountId, long recieverId);
}