using ChatPractice.DAL.Models;

namespace BelvedereFood.DAL.Models;

public class Dialogue : BaseModel
{
    public User UserOne { get; set; }
    public long UserOneId { get; set; }
    public User UserTwo { get; set; }
    public long UserTwoId { get; set; }
}