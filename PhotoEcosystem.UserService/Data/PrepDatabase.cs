
using Microsoft.EntityFrameworkCore;

namespace PhotoEcosystem.UserService.Data
{
    public static class PrepDatabase
    {
        public static void PreparationDatabase(IApplicationBuilder app, bool isProduction)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDbContext context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                SeedData(context, isProduction);
            }
        }

        private static void SeedData(AppDbContext context, bool isProduction)
        {
            if(isProduction)
            {
                try
                {
                    Console.WriteLine($"---> Попытка применить миграцию БД");
                    context.Database.Migrate();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"---> Невозможно применить миграцию к БД:\n{ex.Message}");
                }
            }

            if(!context.Users.Any())
            {
                Console.WriteLine($"---> Заполнение базы данных тестовыми данными");

                context.Users.AddRange(
                    new Models.User("admin", "admin12345", "admin@mail.ru"),
                    new Models.User("user1", "user1", "user1@mail.ru"),
                    new Models.User("user2", "user2", "user2@mail.ru"),
                    new Models.User("user3", "user3", "user3@mail.ru")
                );

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine($"---> В базе данных уже есть пользователи");        
            }
        }
    }
}
