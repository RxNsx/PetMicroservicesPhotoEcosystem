using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория фотографий
    /// </summary>
    public interface IPhotoRepository
    {
        /// <summary>
        /// Добавить фото
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public Task AddAsync(Guid userId, Photo photo);
        /// <summary>
        /// Удалить фото
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task RemoveAsync(Guid id);
        /// <summary>
        /// Получить фото по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Photo> GetByIdAsync(Guid id);
        /// <summary>
        /// Существует ли такая фотография с таким названием
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> IsPhotoExistsAsync(Guid userId, string name);
        /// <summary>
        /// Получить все фотографии пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<Photo>> GetAllPhotoByUserIdAsync(Guid userId);
        /// <summary>
        /// Получить все фотографии сервиса
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public Task<List<Photo>> GetAllAsync();
        /// <summary>
        /// Сохранение изменений в БД
        /// </summary>
        /// <returns></returns>
        public bool SaveChangesAsync();
    }
}