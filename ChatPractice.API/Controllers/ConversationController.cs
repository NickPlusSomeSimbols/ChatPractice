using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.BLL.Services.ConversationService;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ConversationController : ControllerBase
{
    private readonly IConversationService _conversationService;

    public ConversationController(IConversationService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet("GetAllConversations")]
    public async Task<Result<List<Dialogue>>> GetAllConversations()
    {
        await _conversationService.GetAllConversations();

        return Result.Success();
    }
}
