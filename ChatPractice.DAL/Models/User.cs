namespace ChatPractice.DAL.Models;
public class User : BaseModel
{
    public string? Email { get; set; }
    public string? Name { get; set; }
    public int Age { get; set; }
}

