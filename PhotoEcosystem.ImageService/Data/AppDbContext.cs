using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
