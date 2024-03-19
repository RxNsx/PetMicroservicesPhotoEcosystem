using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Interfaces
{
    /// <summary>
    /// Интерфейс взаимодействия с альбомами
    /// </summary>
    public interface IAlbumRepository
    {
        /// <summary>
        /// Получить все альбомы
        /// </summary>
        /// <returns></returns>
        Task<List<Album>> GetAllByUserIdAsync(Guid userId);

        /// <summary>
        /// Получение альбома по айдишнику
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        Task<Album?> GetAlbumByIdAsync(Guid albumId);

        /// <summary>
        /// Получить все альбомы
        /// </summary>
        /// <returns></returns>
        Task<List<Album>> GetAllAlbumsAsync();

        /// <summary>
        /// Создать альбом у пользователя
        /// </summary>
        /// <returns></returns>
        Task<Album> CreateAlbumByUserAsync(Album album);

        /// <summary>
        /// Обновление альбома
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        Task<Album> UpdateAlbumAsync(Album album);

        /// <summary>
        /// Сохранение изменений в контексте
        /// </summary>
        Task<bool> SaveChangesAsync();

        /// <summary>
        /// Удаление альбома
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        Task RemoveAlbumAsync(Guid albumId);
    }
}
