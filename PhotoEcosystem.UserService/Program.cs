using System.Reflection;
using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.UserService.Data;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(opts =>
{
    opts.UseNpgsql(builder.Configuration["ConnectionStrings:PostgreConnectionString"]);
});

builder.Services.AddMediatR(conf =>
{
    conf.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
});

var app = builder.Build();
PrepDatabase.PreparationDatabase(app, builder.Environment.IsProduction());

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();
app.MapControllers();
app.Run();