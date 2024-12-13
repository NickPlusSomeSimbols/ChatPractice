using System.ComponentModel.DataAnnotations;

namespace ChatPractice.DAL.Models;
public class BaseModel
{
    [Key]
    public long Id { get; set; }
}
