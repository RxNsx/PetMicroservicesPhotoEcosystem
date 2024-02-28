using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Queries.Photos
{
    /// <summary>
    /// Запрос на получение фото по айди
    /// </summary>
    public class GetPhotoByIdQuery : IRequest<Photo>
    {
        public Guid PhotoId { get; private set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public GetPhotoByIdQuery(Guid photoId)
        {
            PhotoId = photoId;
        }
    }
}
