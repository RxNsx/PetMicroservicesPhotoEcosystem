using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.UserService.Data;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Repositories
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<UserRepository> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public UserRepository(AppDbContext context,
            ILogger<UserRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        /// <summary>
        /// Создает пользователя
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        public async Task<User> CreateUserAsync(User createUser)
        {
            if(await IsUserExists(createUser.Login))
            {
                _logger.LogError("Пользователь с именем {Login} уже существует", createUser.Login);
                return null;
            }

            _logger.LogInformation("Создание пользователя с логином: {login}", createUser.Login);
            var user = await _context.Users.AddAsync(createUser);
            await SaveChangesAsync();
            return user.Entity;
        }

        /// <summary>
        /// Удаляет пользователя по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteUserAsync(Guid id)
        {
            _logger.LogInformation("Удаление пользователя с id:{id}", id);
            var user = await GetUserByIdAsync(id);
            if(user is not null)
            {
                _context.Users.Remove(user);
                await SaveChangesAsync();
                _logger.LogInformation("Пользователь с id:{id} удалён", id);
            }
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllUsersAsync()
        {
            _logger.LogInformation($"Получение всех пользователей");
            return await _context.Users.AsNoTracking().ToListAsync() ?? new List<User>();
        }

        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<User> GetUserByIdAsync(Guid id)
        {
            _logger.LogInformation("Поиск пользователя по id:{id}", id);
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if(user is null)
            {
                _logger.LogError("Пользователя не существует с id:{id}", id);
                return null;
            }

            return user;
        }

        /// <summary>
        /// Проверка существует ли пользователь с таким логином
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public async Task<bool> IsUserExists(string login)
        {
            _logger.LogInformation($"Проверка существует ли пользователь в базе данных");
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
            return user is null;
        }

        /// <summary>
        /// Обновление данных пользователя
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        public async Task<User> UpdateUserAsync(User updateUser)
        {
            _logger.LogInformation("Обновление пользователя c id:{id}", updateUser.Id);
            var user = await GetUserByIdAsync(updateUser.Id);
            if(user is null)
            {
                return null;
            }

            user.SetLogin(updateUser.Login);
            user.SetPassword(updateUser.Password);
            user.SetEmail(updateUser.Email);
            var updatedUser = _context.Users.Update(user);
            await SaveChangesAsync();
            return updatedUser.Entity;
        }

        /// <summary>
        /// Сохраняет все изменения в контексте
        /// </summary>
        /// <returns></returns>
        private async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
