using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Data
{

    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }
    }
}
