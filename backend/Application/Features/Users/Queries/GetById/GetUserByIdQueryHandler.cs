using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using Application.Features.Users.Errors;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetUserByIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByIdQuery, UserDto>
{
    public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetById(request.Id, cancellationToken);
        if (user is null)
            throw new UserNotFoundException(request.Id);
        return user.ToResponse();
    }
}