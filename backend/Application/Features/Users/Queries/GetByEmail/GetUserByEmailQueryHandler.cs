using Application.Abstractions.Persistence;
using Application.Mappings;
using Application.Features.Users.Dtos;
using Application.Features.Users.Errors;
using MediatR;

namespace Application.Features.Users.Queries.GetByEmail;

public class GetUserByEmailQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetUserByEmailQuery, UserDto>
{
    public async Task<UserDto>Handle(GetUserByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.Users.GetByEmail(request.Email, cancellationToken);
        if (user is null)
            throw new EmailNotFoundException(request.Email);
        return user.ToResponse();
    }
}