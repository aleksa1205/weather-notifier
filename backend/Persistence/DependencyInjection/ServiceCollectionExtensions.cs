using Application.Abstractions.Persistence;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Persistence.Repositories;

namespace Persistence.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUserRepository, UserRepository>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .AddDbContext<ApplicationDbContext>((provider, options) =>
            {
                var connectionOptions = provider
                    .GetRequiredService<IOptions<ConnectionStrings>>()
                    .Value;
                options.UseNpgsql(connectionOptions.WeatherNotifier);
            });
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        return services
            .Configure<ConnectionStrings>(configuration.GetSection(nameof(ConnectionStrings)))
            .AddRepositories()
            .AddDatabase(configuration);
    }
}