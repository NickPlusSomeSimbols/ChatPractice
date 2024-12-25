using Ardalis.Result;
using BelvedereFood.DAL.Models;

namespace ChatPractice.BLL.Services.ConversationService;

public interface IDialogueService
{
    Task<Result<List<Dialogue>>> GetAllDialogues(); // TODO change to DTO
    Task<Result> CreateDialogue(long recieverId);
}
