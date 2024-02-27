using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PhotoEcosystem.ImageService.Data;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Middlewares;
using PhotoEcosystem.ImageService.Repositories;
using PhotoEcosystem.ImageService.Settings;
using PhotoEcosystem.ImageService.SyncDataClient;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///Настройки бд
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]); 
});

///Настройки сваггера
builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "ImageServiceAPI",
        Version = "v1",
        Description = "API для управления фотографиями и альбомами"
    });

    var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
    cfg.IncludeXmlComments(xmlDocPath, true);
});

///Настроики медиатра
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

///Настройки из файла конфигурации
builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);

///Настройки брокера
builder.Services.AddMassTransit(busConfigurator =>
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

//Подключение http клиента для синхронной связи
builder.Services.AddHttpClient<IUserHttpDataClient, UserHttpDataClient>();
///Настройки репозиториев scoped
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();
///Предзаполнение базы данных
await PrepDatabase.PreparationDatabaseAsync(app, app.Environment.IsProduction());

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.Run();