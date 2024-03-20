using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Data;
using PhotoEcosystem.ImageService.Settings;
using MassTransit;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Repositories;

namespace PhotoEcosystem.ImageService.Extensions.ServiceCollections;

/// <summary>
/// Класс расширений
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Подключение провайдера базы данных
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="builder"></param>
    public static IServiceCollection AddDatabaseProvider(this IServiceCollection serviceCollection, WebApplicationBuilder builder)
    {
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
            options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgresConnectionString"]);
        });
        
        return serviceCollection;
    }

    /// <summary>
    /// Подключение MediatR
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddMediatR(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(conf =>
        {
            conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
        });

        return serviceCollection;
    }
    
    /// <summary>
    /// Подключение MassTransit
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddMasstransitConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMassTransit(busConfigurator =>
        {
            busConfigurator.SetKebabCaseEndpointNameFormatter();
            busConfigurator.UsingRabbitMq((context, configurator) =>
            {
                var rabbitMqSettings = context.GetRequiredService<RabbitMqSettings>();
                configurator.Host(new Uri(rabbitMqSettings.Host), h =>
                {
                    h.Username(rabbitMqSettings.UserName);
                    h.Password(rabbitMqSettings.Password);
                });

                configurator.ConfigureEndpoints(context);
            });
        });

        return serviceCollection;
    }

    /// <summary>
    /// Scoped зависимости репозиториев
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <returns></returns>
    public static IServiceCollection AddScopedRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IPhotoRepository, PhotoRepository>();
        serviceCollection.AddScoped<IAlbumRepository, AlbumRepository>();

        return serviceCollection;
    }
}