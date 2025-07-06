<<<<<<< HEAD
﻿using Application.Common.Interfaces;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
=======
﻿using Domain.Users;
>>>>>>> e003ac1a8c9913f451f056e58ebf88ff52e51a35
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
<<<<<<< HEAD
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        return services;
    }

    private static IServiceCollection AddDatabase(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseInMemoryDatabase("WeatherNotifierDb"));
        return services;
=======
        return services.AddScoped<IUserRepository, UserRepository>();
>>>>>>> e003ac1a8c9913f451f056e58ebf88ff52e51a35
    }

    public static IServiceCollection AddPersistence(this IServiceCollection services)
    {
<<<<<<< HEAD
        return services
            .AddRepositories()
            .AddDatabase();
=======
        return services.AddRepositories();
>>>>>>> e003ac1a8c9913f451f056e58ebf88ff52e51a35
    }
}