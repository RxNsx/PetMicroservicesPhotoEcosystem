using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;

namespace PhotoEcosystem.ImageService.Domain.Interfaces;

public interface IAlbumRepository
{
    /// <summary>
    /// Добавить альбом
    /// </summary>
    /// <param name="album"></param>
    /// <returns></returns>
    Task<AlbumAggregate> AddAlbumAsync(string name);
    
    /// <summary>
    /// Получить по айди
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<AlbumAggregate> GetByIdAsync(Guid id);
}