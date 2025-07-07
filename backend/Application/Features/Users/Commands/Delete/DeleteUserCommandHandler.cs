using Application.Abstractions.CQS;
using Application.Abstractions.Persistence;
using Application.Features.Users.Errors;
using FluentResults;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : ICommandHandler<DeleteUserCommand, Unit>
{
    public async Task<Result<Unit>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetById(request.Id, cancellationToken);
        if (user is null)
            return Result.Fail<Unit>(new UserNotFoundError(request.Id));
        
        unitOfWork.Users.Delete(user);
        await unitOfWork.SaveChanges(cancellationToken);
        return Result.Ok(Unit.Value);
    }
}