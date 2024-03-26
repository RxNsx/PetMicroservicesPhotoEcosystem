using System.Reflection;
using Microsoft.Extensions.Options;
using PhotoEcosystem.ImageService.Data;
using PhotoEcosystem.ImageService.Extensions.ServiceCollections;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Middlewares;
using PhotoEcosystem.ImageService.Repositories;
using PhotoEcosystem.ImageService.Settings;
using PhotoEcosystem.ImageService.SyncDataClient;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers(configure =>
{
    configure.SuppressAsyncSuffixInActionNames = true;
});

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
builder.AddSwaggerConfiguration();

services.AddDatabaseProvider(builder);
services.AddMediatR();
services.AddAutoMapper(Assembly.GetExecutingAssembly());
services.Configure<RabbitMqSettings>(
    builder.Configuration.GetSection("RabbitMqSettings"));
services.AddSingleton(sp =>
    sp.GetRequiredService<IOptions<RabbitMqSettings>>().Value);
services.AddMasstransitConfiguration();

services.AddHttpClient<IUserHttpDataClient, UserHttpDataClient>();
services.AddScopedRepositories();
services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();
await PrepDatabase.PreparationDatabaseAsync(app, app.Environment.IsProduction());

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();
app.Run();