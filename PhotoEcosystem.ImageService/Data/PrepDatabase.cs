
using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Data
{
    public static class PrepDatabase
    {
        public static async Task PreparationDatabaseAsync(IApplicationBuilder app, bool isProduction)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                await SeedDataAsync(context, isProduction);
            }
        }

        private static async Task SeedDataAsync(AppDbContext context, bool isProduction)
        {
            if(isProduction)
            {
                try
                {
                    Console.WriteLine($"----> Попытка применения миграции");
                    await context.Database.MigrateAsync();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"----> Ошибка применения миграции {ex.Message}");
                }
            }

            if(!context.Users.Any())
            {
                SeedUsers(context);
            }

            var user = context.Users.FirstOrDefault();

            if (!context.Photos.Any() && context.Users.Any())
            {
                SeedPhotos(context, user);
            }
            if(context.Photos.Any() && context.Users.Any() && !context.Albums.Any())
            {
                SeedAlbums(context, user);
            }
        }

        private static void SeedAlbums(AppDbContext context, User user)
        {
            context.Albums.AddRange(
                new Album()
                {
                    Id = Guid.NewGuid(),
                    Name = "album1",
                    IsFavourite = false,
                    IsPrivate = false,
                    LikesCount = 0,
                    User = user
                }
            );

            context.SaveChanges();
        }

        /// <summary>
        /// Заполнение базы пользователями
        /// </summary>
        /// <param name="context"></param>
        private static void SeedUsers(AppDbContext context)
        {
            context.AddRange(
                new User()
                {
                    Id = Guid.NewGuid(),
                    Name = "user1",
                    Email = "user1@mail.ru",
                    LastTimeOnline = DateTime.UtcNow
                },
                new User()
                {
                    Id  = Guid.NewGuid(),
                    Name = "user2",
                    Email = "user2@mail.ru",
                    LastTimeOnline = DateTime.UtcNow
                }
            );

            context.SaveChanges();
        }

        /// <summary>
        /// Заполнение базы с фотографиями
        /// </summary>
        /// <param name="context"></param>
        private static void SeedPhotos(AppDbContext context, User user)
        {
            context.Photos.AddRange(
                new Photo()
                {
                    Id = Guid.NewGuid(),
                    Name = "Photo1",
                    IsFavourite = false,
                    IsPrivate = false,
                    LikesCount = 0,
                    User = user
                },
                new Photo()
                {
                    Id = Guid.NewGuid(),
                    Name = "Photo2",
                    IsFavourite = false,
                    IsPrivate = false,
                    LikesCount = 0,
                    User = user
                },
                new Photo()
                {
                    Id = Guid.NewGuid(),
                    Name = "Photo3",
                    IsFavourite = false,
                    IsPrivate = false,
                    LikesCount = 0,
                    User = user,
                }
            );

            context.SaveChanges();
        }
    }
}
