using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using FluentResults;
using Application.Abstractions.CQS;
using Application.Features.Users.Errors;

namespace Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IQueryHandler<GetUserByIdQuery, UserDto>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetById(request.Id, cancellationToken);
        if (user is null)
            return Result.Fail<UserDto>(new UserNotFoundError(request.Id));
        return Result.Ok(user.ToResponse());
    }
}