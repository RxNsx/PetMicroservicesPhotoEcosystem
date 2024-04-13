using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;

namespace PhotoEcosystem.ImageService.Infrastructure;

public class AppDbContext : DbContext, IUnitOfWork
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }

    public DbSet<AlbumAggregate> Albums { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}