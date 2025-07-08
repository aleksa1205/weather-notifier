using Application.Behaviors;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using MediatR;

namespace Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    private static IServiceCollection AddValidation(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly)
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly))
            .AddValidation();
    }
}