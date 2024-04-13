using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using PhotoEcosystem.ImageService.Infrastructure.Persistence;
using Shared;

namespace PhotoEcosystem.ImageService.Infrastructure;

public static class InfrastructureRegisteredServices
{
    public static IServiceCollection AddInfrastructureRegisteredServices(this IServiceCollection services,
        ConfigurationManager builderConfiguration, bool isProduction)
    {
        ConfigureDbContextConnections(services, builderConfiguration, isProduction);
        
        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<AppDbContext>());
        services.AddScoped<IAlbumRepository, AlbumRepository>();
        services.AddScoped<IPhotoRepository, PhotoRepository>();
        
        AddMigrations(services);

        return services;
    }

    private static void ConfigureDbContextConnections(IServiceCollection services,
        ConfigurationManager builderConfiguration, bool isProduction)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            if (isProduction)
            {
                Ensure.IsNotNull(builderConfiguration.GetConnectionString("DefaultConnection"));
                options.UseNpgsql(builderConfiguration.GetConnectionString("DefaultConnection"));
            }
            else
            {
                Ensure.IsNotNull(builderConfiguration.GetConnectionString("PostgreConnectionString"));
                options.UseNpgsql(builderConfiguration.GetConnectionString("PostgreConnectionString"));            
            }
        });
    }

    private static void AddMigrations(IServiceCollection services)
    {
        var scope = services.BuildServiceProvider().CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        if (context.Database.GetPendingMigrations().Any())
        {
            context.Database.Migrate();
        }
    }
}

