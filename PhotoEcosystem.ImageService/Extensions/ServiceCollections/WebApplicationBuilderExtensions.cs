using System.Reflection;
using Microsoft.OpenApi.Models;

namespace PhotoEcosystem.ImageService.Extensions.ServiceCollections;

/// <summary>
/// Класс расширений для WebApplicationBuilder
/// </summary>
public static class WebApplicationBuilderExtensions
{
    /// <summary>
    /// Добавление конфигурации сваггер
    /// </summary>
    /// <param name="serviceCollection"></param>
    /// <param name="builder"></param>
    /// <returns></returns>
    public static void AddSwaggerConfiguration(this WebApplicationBuilder builder)
    {
        builder.Services.AddSwaggerGen(cfg =>
        {
            cfg.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "ImageServiceAPI",
                Version = "v1",
                Description = "API Для взаимодействия с изображениями"
            });

            var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
            cfg.IncludeXmlComments(xmlDocPath, true);
        });
    }
}