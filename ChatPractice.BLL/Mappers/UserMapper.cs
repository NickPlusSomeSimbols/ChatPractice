using ChatPractice.DAL.Models;
using ChatPractice.DTO.User;
using Riok.Mapperly.Abstractions;

namespace ChatPractice.BLL.Mappers;

[Mapper]
public static partial class UserMapper
{
    public static partial UserDto MapToDto(this User user);
    public static partial List<UserDto> MapToDtos(this List<User> users);
}