using Application.Common.Interfaces;
using Application.Common.Mappings;
using Application.Features.Users.Dtos;
using Application.Features.Users.Errors;
using Domain.Users;
using MediatR;

namespace Application.Features.Users.Queries.ById;

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