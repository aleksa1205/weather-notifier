using Application.Abstractions.CQS;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public record DeleteUserCommand(Guid Id) : ICommand<Unit>;