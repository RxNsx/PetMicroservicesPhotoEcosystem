using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Application;
using PhotoEcosystem.ImageService.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services
    .ApplicationRegisteredServices()
    .AddInfrastructureRegisteredServices(builder.Configuration,
        builder.Environment.IsProduction());

// builder.Host.UseSerilog((context, configuration) =>
// {
//     configuration.ReadFrom.Configuration(context.Configuration);
// });

var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapControllers();
}

// app.UseHttpsRedirection();
app.Run();