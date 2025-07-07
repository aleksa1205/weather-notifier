using Application.Abstractions.CQS;
using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Queries.GetByEmail;

public record GetUserByEmailQuery(string Email) : IQuery<UserDto>;