using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Interfaces
{
    /// <summary>
    /// Репозиторий для работы с пользователями
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="createUser"></param>
        /// <returns></returns>
        Task<User> CreateUserAsync(User createUser);
        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        Task<User> UpdateUserAsync(User updateUser);
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteUserAsync(Guid id);
        /// <summary>
        /// Получить всех пользователей
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllUsersAsync();
        /// <summary>
        /// Получить пользователя по идентификатору
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<User> GetUserByIdAsync(Guid id);
        /// <summary>
        /// Проверка на существование пользователя в базе данных по логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        Task<bool> IsUserExists(string login);
    }
}
