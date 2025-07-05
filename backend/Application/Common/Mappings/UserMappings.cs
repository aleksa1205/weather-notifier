using Application.Features.Users.Dtos;
using Domain.Users;

namespace Application.Common.Mappings;

public static class UserMappings
{
    public static UserDto ToResponse(this User user) => new(user.Id, user.Email, user.City);
}
