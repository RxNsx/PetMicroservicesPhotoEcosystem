using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PhotoEcosystem.ImageService.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]); 
});

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

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
PrepDatabase.PreparationDatabaseAsync(app, app.Environment.IsProduction());

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();