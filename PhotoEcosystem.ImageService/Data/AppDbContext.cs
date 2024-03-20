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
        /// Построение связей объекта FLUENT API
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.Albums)
                .WithOne(a => a.User)
                .HasForeignKey(a => a.UserId);


            modelBuilder.Entity<Album>()
                .HasMany(a => a.Photos)
                .WithOne(p => p.Album)
                .HasForeignKey(p => p.AlbumId);
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
