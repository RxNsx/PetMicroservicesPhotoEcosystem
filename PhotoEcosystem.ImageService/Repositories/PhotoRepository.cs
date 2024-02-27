using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.ImageService.Data;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Repositories
{
    /// <summary>
    /// Репозиторий для работы с фотографиями
    /// </summary>
    public sealed class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext _context;
        private readonly ILogger<PhotoRepository> _logger;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="context"></param>
        public PhotoRepository(AppDbContext context, ILogger<PhotoRepository> logger)
        {
            this._context = context;
            this._logger = logger;
        }

        /// <summary>
        /// Добавить фото
        /// </summary>
        /// <param name="photo"></param>
        /// <returns></returns>
        public async Task AddAsync(Guid userId, Photo photo)
        {
            _logger.LogInformation($"Добавление фото с именем: {photo.Name}");
            if(!await IsPhotoExistsAsync(userId, photo.Name))
            {
                var user = await GetCurrentUserAsync(userId);
                user.Albums.FirstOrDefault(a => a.Id == null).Photos.Add(photo);
                await _context.Photos.AddAsync(photo);
                SaveChangesAsync();
            }
        }

        /// <summary>
        /// Удалить фото
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task RemoveAsync(Guid id)
        {
            _logger.LogInformation($"Удаление фото по Id:{id}");
            var photo = await GetByIdAsync(id);
            _context.Photos.Remove(photo);
            SaveChangesAsync();
        }

        /// <summary>
        /// Получение фото по айди
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Photo> GetByIdAsync(Guid id)
        {
            _logger.LogInformation($"Получение фото по Id:{id}");
            var photo = await _context.Photos.FirstOrDefaultAsync(p => p.Id == id);
            if(photo is null)
            {
                throw new ArgumentNullException(nameof(photo));
            }

            return photo;
        }

        /// <summary>
        /// Существует ли фотография у пользователя с таким названием
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<bool> IsPhotoExistsAsync(Guid userId, string name)
        {
            _logger.LogInformation($"Проверка существует ли фотография с именем: {name} у пользователя: {userId}");
            var user = await GetCurrentUserAsync(userId);
            if (user is null)
            {
                _logger.LogError($"Нету такого пользователя чтобы добавить фотографию");
                throw new ArgumentNullException(nameof(user));
            }

            var isPhotoWithNameExists = user.Albums.Any(a => a.Photos.Any(p => p.Name == name));
            return isPhotoWithNameExists;
        }

        /// <summary>
        /// Получить все фотографии пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<List<Photo>> GetAllPhotoByUserIdAsync(Guid userId)
        {
            _logger.LogInformation($"Получение фотографии пользователя: {userId}");
            var user = await GetCurrentUserAsync(userId);
            if (user is null)
            {
                _logger.LogError($"Нету такого пользователя чтобы получить все фотографии");
                throw new ArgumentNullException(nameof(user));
            }

            var userPhotos = await _context.Photos
                .Include(p => p.Album)
                .Where(p => p.AlbumId != null && p.Album.UserId == userId)
                .Union
                (
                    _context.Photos
                        .Include(p => p.Album)
                        .Where(p => p.AlbumId == null && p.UserId == userId)

                )
                .ToListAsync();

            return userPhotos;
        }

        /// <summary>
        /// Получить все фотографии
        /// </summary>
        /// <returns></returns>
        public async Task<List<Photo>> GetAllAsync()
        {
            _logger.LogInformation($"Получение всех фото всех пользователей");
            return await _context.Photos.ToListAsync();
        }

        /// <summary>
        /// Сохранение измененных сущностей
        /// </summary>
        /// <returns></returns>
        public bool SaveChangesAsync()
        {
            return (_context.SaveChanges() >= 0);
        }

        /// <summary>
        /// Получение пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<User> GetCurrentUserAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
