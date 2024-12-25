using ChatPractice.DTO.User;

namespace ChatPractice.DTO.UserSession;

public class DialogueDto
{
    public UserDto UserOne { get; set; }
    public long UserOneId { get; set; }
    public UserDto UserTwo { get; set; }
    public long UserTwoId { get; set; }
}

