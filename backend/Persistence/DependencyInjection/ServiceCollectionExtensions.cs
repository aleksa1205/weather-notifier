using Application.Abstractions.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        return services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("WeatherNotifierDb"));
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        return services
            .AddRepositories()
            .AddDatabase();
    }
}