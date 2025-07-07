using Application.Features.Users.Dtos;
using Domain.Users;

namespace Application.Mappings;

public static class UserMappings
{
    public static UserDto ToResponse(this User user) => new(user.Id, user.Email, user.City);
    public static User ToRequest(this CreateUserDto user) => new(user.email, user.city);
}
