﻿using Application.Features.Users.Commands.Create;
using Application.Features.Users.Commands.Delete;
using Application.Features.Users.Dtos;
using Application.Features.Users.Queries.GetByEmail;
using Application.Features.Users.Queries.GetById;
using MediatR;
using Presentation.Extensions;

namespace Presentation.Endpoints.Users;

public static class UserHandlers
{
    internal static async Task<IResult> GetById(ISender mediator, CancellationToken cancellationToken, Guid id) =>
        (await mediator.Send(new GetUserByIdQuery(id), cancellationToken)).ToResponse();
    
    internal static async Task<IResult> GetByEmail(ISender mediator, CancellationToken cancellationToken, string email) =>
        (await mediator.Send(new GetUserByEmailQuery(email), cancellationToken)).ToResponse();

    internal static async Task<IResult> Create(ISender mediator, CancellationToken cancellationToken,
        CreateUserDto user) => (await mediator.Send(new CreateUserCommand(user), cancellationToken)).ToResponse();

    internal static async Task<IResult> Delete(ISender mediator, CancellationToken cancellationToken, Guid id) =>
        (await mediator.Send(new DeleteUserCommand(id), cancellationToken)).ToResponse();
}