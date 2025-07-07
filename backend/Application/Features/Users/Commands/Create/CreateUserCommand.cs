using Application.Abstractions.CQS;
using Application.Features.Users.Dtos;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommand(CreateUserDto User) : ICommand<UserDto>;