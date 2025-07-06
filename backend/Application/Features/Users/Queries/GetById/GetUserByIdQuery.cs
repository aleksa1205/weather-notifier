using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetById;
public record GetUserByIdQuery(Guid Id) : IRequest<UserDto>;