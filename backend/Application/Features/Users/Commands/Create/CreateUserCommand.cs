using Application.Features.Users.Dtos;
using FluentResults;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public record CreateUserCommand(CreateUserDto User) : IRequest<UserDto>;