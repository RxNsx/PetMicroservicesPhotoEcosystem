using PhotoEcosystem.ImageService.Domain.Entities;

namespace PhotoEcosystem.ImageService.Application.Abstractions.Data;

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
        public Task RemoveAsync(Guid photoId, Guid userId);
        /// <summary>
        /// Получить фото по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Photo> GetPhotoByIdAsync(Guid id);
        /// <summary>
        /// Обновление фотографии
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="photo"></param>
        /// <returns></returns>
        public Task<Photo> UpdatePhotoAsync(Guid userId, Photo photo);
        /// <summary>
        /// Существует ли такая фотография с таким названием
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
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
}