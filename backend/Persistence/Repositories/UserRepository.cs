using Domain.User;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Repositories;

internal sealed class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(ApplicationDbContext context) : base(context) { }

    public Task<User?> GetById(Guid id)
    {
        return DbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
    }

    public Task<User?> GetByEmail(string email)
    {
        return DbContext.Users.SingleOrDefaultAsync(x => x.Email == email);
    }
}
