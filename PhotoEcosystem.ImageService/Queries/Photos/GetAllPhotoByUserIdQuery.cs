using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Queries.Photos
{
    /// <summary>
    /// Запрос фотографий конкретного пользователя
    /// </summary>
    public class GetAllPhotoByUserIdQuery : IRequest<List<Photo>>
    {
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public readonly Guid UserId;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GetAllPhotoByUserIdQuery(Guid userId)
        {
            this.UserId = userId;
        }
    }
}
