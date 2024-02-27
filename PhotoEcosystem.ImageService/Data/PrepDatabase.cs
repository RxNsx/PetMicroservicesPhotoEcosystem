
using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.SyncDataClient;

namespace PhotoEcosystem.ImageService.Data
{
    public static class PrepDatabase
    {
        public static async Task PreparationDatabaseAsync(IApplicationBuilder app, bool isProduction)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                var httpDataClient = scope.ServiceProvider.GetRequiredService<IUserHttpDataClient>();
                var users = await httpDataClient.GetAllUsersAsync();
                await SeedDataAsync(context, users, isProduction);
            }
        }

        /// <summary>
        /// Заполнение базы данных
        /// </summary>
        /// <param name="context"></param>
        /// <param name="users"></param>
        /// <param name="isProduction"></param>
        /// <returns></returns>
        private static async Task SeedDataAsync(AppDbContext context, List<User> users, bool isProduction)
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
                await SeedUsers(context, users);
            }
            if (context.Users.Any() && !context.Albums.Any())
            {
                await SeedAlbumsForUser(context);
            }
            if (context.Users.Any() && context.Albums.Any() && !context.Photos.Any())
            {
                await SeedPhotosForUser(context);
            }

        }

        /// <summary>
        /// Заполнение базы пользователями
        /// </summary>
        /// <param name="context"></param>
        private static async Task SeedUsers(AppDbContext context, List<User> users)
        {
            if(users.Count > 0 && users is not null)
            {
                context.AddRange(users);
                await context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Добавить альбом пользователю
        /// </summary>
        /// <param name="context"></param>
        /// <param name="user"></param>
        private static async Task SeedAlbumsForUser(AppDbContext context)
        {
            var user = context.Users.OrderBy(u => u.Id).FirstOrDefault();
            if (user is not null)
            {
                if (user.Albums.Count == 0)
                {
                    await context.Albums.AddAsync(
                        new Album()
                        {
                            Id = Guid.NewGuid(),
                            UserId = user.Id,
                            User = user,
                            Name = "Album1",
                            IsFavourite = false,
                            IsPrivate = false,
                            LikesCount = 0,
                            Photos = new List<Photo>(),
                        }
                    );

                    await context.SaveChangesAsync();
                };
            }
        }


        /// <summary>
        /// Заполнение базы с фотографиями
        /// </summary>
        /// <param name="context"></param>
        private static async Task SeedPhotosForUser(AppDbContext context)
        {
            var user = context.Users.OrderBy(u => u.Id).FirstOrDefault();
            if (user is not null)
            {
                if(user.Albums.Count > 0)
                {
                    var album = await context.Albums.Where(a => a.UserId == user.Id).FirstOrDefaultAsync();
                    await context.Photos.AddRangeAsync(
                        new List<Photo>()
                        {
                            new Photo()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Photo1",
                                IsFavourite = false,
                                IsPrivate = false,
                                AlbumId = album.Id,
                                Album = album,
                                User = user,
                                UserId = user.Id,
                                LikesCount = 0,
                            },
                            new Photo()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Photo2",
                                IsFavourite = false,
                                IsPrivate = false,
                                AlbumId = album.Id,
                                Album = album,
                                User = user,
                                UserId = user.Id,
                                LikesCount = 0,
                            },
                            new Photo()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Photo3",
                                IsFavourite = false,
                                IsPrivate = false,
                                AlbumId = album.Id,
                                Album = album,
                                User = user,
                                UserId = user.Id,
                                LikesCount = 0,
                            }
                        }
                    );
                }

                await context.Photos.AddRangeAsync(
                    new List<Photo>()
                    {
                        new Photo()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Photo1",
                            IsFavourite = false,
                            IsPrivate = false,
                            AlbumId = null,
                            Album = null,
                            User = user,
                            UserId = user.Id,
                            LikesCount = 0,
                        },
                        new Photo()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Photo2",
                            IsFavourite = false,
                            IsPrivate = false,
                            AlbumId = null,
                            Album = null,
                            User = user,
                            UserId = user.Id,
                            LikesCount = 0,
                        },
                    }
                );

                await context.SaveChangesAsync();
            }
        }
    }
}
