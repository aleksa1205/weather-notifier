using Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services.AddScoped<IUserRepository, UserRepository>();
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services.AddRepositories();
    }
}