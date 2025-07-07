using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using Application.Features.Users.Errors;
using MediatR;
using Application.Abstractions.CQS;
using FluentResults;

namespace Application.Features.Users.Queries.GetByEmail;

public class GetUserByEmailQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<Result<UserDto>>Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByEmail(request.Email, cancellationToken);
        if (user is null)
            return Result.Fail<UserDto>(new EmailNotFoundError(request.Email));
        return Result.Ok(user.ToResponse());
    }
}