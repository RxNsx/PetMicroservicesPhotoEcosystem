using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using PhotoEcosystem.UserService.Data;
using Testcontainers.PostgreSql;
using Xunit;

namespace UserService.Tests
{
    /// <summary>
    /// Фактори для интеграционных тестов
    /// </summary>
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Program>, IAsyncLifetime
    {
        /// <summary>
        /// Конфигурация бд для контейнера
        /// </summary>
        private readonly PostgreSqlContainer _postgreSqlContainer = new PostgreSqlBuilder()
            .WithImage("postgres:latest")
            .WithDatabase("photoecosystem_users")
            .WithUsername("admin")
            .WithPassword("-pl,mju7")
            .Build();

        /// <summary>
        /// Конфигурация вебхоста
        /// </summary>
        /// <param name="builder"></param>
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var dbContext = services.SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<AppDbContext>));
                if (dbContext is not null)
                {
                    services.Remove(dbContext);
                }

                services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseNpgsql(_postgreSqlContainer.GetConnectionString());
                });
            });
        }

        /// <summary>
        /// Запуск контейнера
        /// </summary>
        /// <returns></returns>
        public Task InitializeAsync()
        {
            return _postgreSqlContainer.StartAsync();
        }

        /// <summary>
        /// Удаление контейнера
        /// </summary>
        /// <returns></returns>
        public new Task DisposeAsync()
        {
            return _postgreSqlContainer.StopAsync();
        }
    }
}
