using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using MediatR;
using FluentResults;
using Application.Abstractions.CQS;
using Application.Features.Users.Errors;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<CreateUserCommand, UserDto>
{
    public async Task<Result<UserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        if (await unitOfWork.Users.GetByEmail(request.User.email) is not null)
            return Result.Fail<UserDto>(new DuplicateEmailError(request.User.email));

        var user = request.User.ToRequest();
        unitOfWork.Users.Add(user);
        await unitOfWork.SaveChanges(cancellationToken);
        return Result.Ok(user.ToResponse());
    }
}