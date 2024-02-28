using MediatR;
using PhotoEcosystem.ImageService.Dtos;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Commands.Photos
{
    /// <summary>
    /// Команда добавления фотографий пользователю
    /// </summary>
    public class AddPhotoByUserIdCommand : IRequest
    {
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public Guid UserId { get; private set; }
        /// <summary>
        /// Фотография добавленная пользователем
        /// </summary>
        public Photo Photo { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public AddPhotoByUserIdCommand(Guid userId, Photo photo)
        {
            UserId = userId;
            Photo = photo;
        }
    }
}
