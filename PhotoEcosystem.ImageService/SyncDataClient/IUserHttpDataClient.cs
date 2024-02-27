using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.SyncDataClient
{
    /// <summary>
    /// Интерфейс для работы 
    /// </summary>
    public interface IUserHttpDataClient
    {
        /// <summary>
        /// Запрос всех пользователей
        /// </summary>
        /// <returns></returns>
        public Task<List<User>> GetAllUsersAsync();
    }
}
