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

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", configure =>
    {
        configure.WithOrigins("http://localhost:3000");
    });
});

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
        Description = "API ��� ���������� ��������������"
    });

    var xmlDocFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlDocPath = Path.Combine(AppContext.BaseDirectory, xmlDocFile);
    cfg.IncludeXmlComments(xmlDocPath, true);
});

//����������� �������� �� ������������
builder.Services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings"));
builder.Services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);

//����������� ��
builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]);
});

//����������� ��������
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

//����������� �����������
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

///��������� ������ � ��������
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
app.UseCors("CorsPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();

/// <summary>
/// ��������� ����� ��� ������
/// </summary>
public partial class Program { }