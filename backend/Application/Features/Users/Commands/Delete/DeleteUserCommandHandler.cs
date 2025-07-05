using Application.Common.Interfaces;
using Application.Features.Users.Errors;
using MediatR;

namespace Application.Features.Users.Commands.Delete;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetById(request.Id, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(request.Id);
        
        unitOfWork.Users.Delete(user);
        await unitOfWork.SaveChanges(cancellationToken);
        return Unit.Value;
    }
}