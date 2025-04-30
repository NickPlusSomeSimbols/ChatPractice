using ChatPractice.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPractice.DAL.Repository;
public class ChatRepository
{
    private readonly AppDbContext _context;
    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task SaveMessage(ChatMessage message)
    {
        await _context.ChatMessages.AddAsync(message);
        await _context.SaveChangesAsync();
    }

    //public async Task<List<ChatMessage>> GetChatMessagesAsync(string accountId, string recieverId)
    //{
    //}
}
