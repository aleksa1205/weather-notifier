using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.ById;
public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;