using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
