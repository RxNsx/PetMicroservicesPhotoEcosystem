using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PhotoEcosystem.UserService.Data;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Repositories;

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

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]);
});
builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();
PrepDatabase.PreparationDatabase(app, builder.Environment.IsProduction());

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();
app.MapControllers();
app.Run();