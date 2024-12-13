namespace ChatPractice.DAL.Models;
public class Message : BaseModel
{
    public long UserId { get; set; }
    public string Text { get; set; }
}
