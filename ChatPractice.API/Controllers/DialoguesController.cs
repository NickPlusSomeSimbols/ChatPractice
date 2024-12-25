using Ardalis.Result;
using BelvedereFood.DAL.Models;
using ChatPractice.BLL.Services.ConversationService;
using Microsoft.AspNetCore.Mvc;

namespace ChatPractice.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class DialoguesController : ControllerBase
{
    private readonly IDialogueService _conversationService;

    public DialoguesController(IDialogueService conversationService)
    {
        _conversationService = conversationService;
    }

    [HttpGet("GetAllDialogues")]
    public async Task<Result<List<Dialogue>>> GetAllDialogues()
    {
        await _conversationService.GetAllDialogues();

        return Result.Success();
    }
}
