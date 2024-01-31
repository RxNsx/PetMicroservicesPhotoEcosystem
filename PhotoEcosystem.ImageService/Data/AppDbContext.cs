using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Data
{
    /// <summary>
    /// Контекст
    /// </summary>
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="opts"></param>
        public AppDbContext(DbContextOptions<AppDbContext> opts):base(opts)
        {
            
        }

        /// <summary>
        /// Пользователи
        /// </summary>
        public DbSet<User> Users { get; set; }
        /// <summary>
        /// Альбомы
        /// </summary>
        public DbSet<Album> Albums { get; set; }
        /// <summary>
        /// Фото
        /// </summary>
        public DbSet<Photo> Photos { get; set; }
    }
}
