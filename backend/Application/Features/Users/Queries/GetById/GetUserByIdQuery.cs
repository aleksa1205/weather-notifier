using Application.Abstractions.CQS;
using Application.Features.Users.Dtos;

namespace Application.Features.Users.Queries.GetById;
public record GetUserByIdQuery(Guid Id) : IQuery<UserDto>;