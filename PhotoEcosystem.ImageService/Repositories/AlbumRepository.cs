using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Data;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Repositories
{
    /// <summary>
    /// Репозиторий для получения альбомов
    /// </summary>
    public class AlbumRepository : IAlbumRepository
    {
        private readonly AppDbContext _context;

        /// <summary>
        /// Конструктор
        /// </summary>
        public AlbumRepository(AppDbContext context)
        {
            this._context = context;
        }

        /// <summary>
        /// Получение альбома по айдишнику
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public async Task<Album?> GetAlbumByIdAsync(Guid albumId)
        {
            return await _context.Albums.FirstOrDefaultAsync(a => a.Id == albumId);
        }

        /// <summary>
        /// Получение всех альбомов пользователя
        /// </summary>
        /// <param name="userId">Айди пользователя</param>
        /// <returns>Список альбомов</returns>
        public Task<List<Album>> GetAllByUserIdAsync(Guid userId)
        {
            return _context.Albums.Where(a => a.UserId == userId).ToListAsync();
        }

        /// <summary>
        /// Получить все альбомы
        /// </summary>
        /// <returns></returns>
        public Task<List<Album>> GetAllAlbumsAsync()
        {
            return _context.Albums.ToListAsync();
        }

        /// <summary>
        /// Создать альбом у пользователя
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public async Task<Album> CreateAlbumByUserAsync(Album album)
        {
            try
            {
                var albumEntity = await _context.Albums.AddAsync(album);
                await SaveChangesAsync();
                return albumEntity.Entity;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Обновление альбома
        /// </summary>
        /// <param name="album"></param>
        /// <returns></returns>
        public async Task<Album> UpdateAlbumAsync(Album album)
        {
            var updateAlbum = await GetAlbumByIdAsync(album.Id);

            if(updateAlbum is null)
            {
                throw new ArgumentNullException(nameof(updateAlbum), "Не существует такого альбома для обновления");
            }

            updateAlbum.Name = album.Name;
            updateAlbum.IsFavourite = album.IsFavourite;
            updateAlbum.IsPrivate = album.IsPrivate;
            await SaveChangesAsync();

            return updateAlbum;
        }

        /// <summary>
        /// Сохранение изменений контекста
        /// </summary>
        /// <returns></returns>
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }

        /// <summary>
        /// Удаление альбома
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        public async Task RemoveAlbumAsync(Guid albumId)
        {
            var album = await _context.Albums.FirstOrDefaultAsync(a => a.Id == albumId);
            if(album is null)
            {
                throw new ArgumentNullException(nameof(album), "Нет такого альбома для удаления");
            }

            _context.Albums.Remove(album);
            await SaveChangesAsync();
        }
    }
}