using System.Reflection;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using PhotoEcosystem.UserService.Data;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Repositories;
using PhotoEcosystem.UserService.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(options =>
{
    options.SuppressAsyncSuffixInActionNames = true;
});
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(cfg =>
{
    cfg.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "UserServiceAPI",
        Version = "v1",
        Description = "API для управления пользователями"
    });

    var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
    cfg.IncludeXmlComments(xmlDocPath, true);
});

//Подключение настроек из конфигурации
builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);

//Подключение бд
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]);
});

//Подключение медиатра
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

//Подключение автомаппера
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

///Настройка работы с брокером
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

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
PrepDatabase.PreparationDatabase(app, builder.Environment.IsProduction());
app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();

/// <summary>
/// Частичный класс для тестов
/// </summary>
public partial class Program { }