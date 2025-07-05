using Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public Task<User?> GetById(Guid id, CancellationToken cancellationToken)
    {
        return DbContext.Users.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public Task<User?> GetByEmail(string email, CancellationToken cancellationToken)
    {
        return DbContext.Users.SingleOrDefaultAsync(x => x.Email == email,cancellationToken);
    }
}
