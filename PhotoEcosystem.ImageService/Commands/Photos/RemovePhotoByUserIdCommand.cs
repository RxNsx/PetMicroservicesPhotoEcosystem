using MediatR;

namespace PhotoEcosystem.ImageService.Commands.Photos
{
    /// <summary>
    /// Команда удаления фотографии
    /// </summary>
    public class RemovePhotoByUserIdCommand : IRequest
    {
        /// <summary>
        /// Айди фото
        /// </summary>
        public Guid PhotoId { get; private set; }
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public Guid UserId { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="photoId"></param>
        public RemovePhotoByUserIdCommand(Guid photoId, Guid userId)
        {
            UserId = UserId;
            PhotoId = photoId;
        }
    }
}
