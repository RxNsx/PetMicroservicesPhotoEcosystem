using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Commands.Photos
{
    /// <summary>
    /// Команда обновления фотографии у пользователя
    /// </summary>
    public class UpdatePhotoByUserIdCommand : IRequest<Photo>
    {
        /// <summary>
        /// Фото для обновления
        /// </summary>
        public Photo Photo { get; private set; }
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public Guid UserId { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public UpdatePhotoByUserIdCommand(Guid userId, Photo photo)
        {
            Photo = photo;
            UserId = userId;
        }
    }
}
