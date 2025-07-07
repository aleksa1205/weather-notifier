using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Commands.Create;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : IRequestHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = request.User.ToRequest();
        unitOfWork.Users.Add(user);
        await unitOfWork.SaveChanges(cancellationToken);
        return user.ToResponse();
    }
}