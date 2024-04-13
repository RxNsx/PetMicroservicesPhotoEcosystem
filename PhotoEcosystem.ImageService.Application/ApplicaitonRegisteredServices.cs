using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;

namespace PhotoEcosystem.ImageService.Application;

public static class ApplicaitonRegisteredServices
{
    public static IServiceCollection ApplicationRegisteredServices(this IServiceCollection services)
    {
        var assembly = typeof(ApplicaitonRegisteredServices).Assembly;
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(assembly);
        });
        
        services.AddValidatorsFromAssembly(assembly);
        return services;
    }
}