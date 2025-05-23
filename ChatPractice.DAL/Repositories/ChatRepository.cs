﻿using ChatPractice.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatPractice.DAL.Repository;
public class ChatRepository : IChatRepository
{
    private readonly AppDbContext _context;
    public ChatRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task SendMessageAsync(ChatMessage message)
    {
        await _context.ChatMessages.AddAsync(message);
        await _context.SaveChangesAsync();
    }

    public async Task<List<ChatMessage>> GetChatMessagesAsync(long accountId, long recieverId)
    {
        var senderMessages = await _context.ChatMessages
            .Where(x => x.SenderId == accountId && x.ReceieverId == recieverId)
            .ToListAsync();

        var recieverMessages = await _context.ChatMessages
            .Where(x => x.SenderId == recieverId && x.ReceieverId == accountId)
            .ToListAsync();

        var totalMessages = senderMessages
            .Concat(recieverMessages)
            .OrderBy(x => x.SendingDate)
            .ToList();

        return totalMessages;
    }
}
