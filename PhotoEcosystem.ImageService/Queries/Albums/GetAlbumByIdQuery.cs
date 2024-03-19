using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Queries.Albums
{
    /// <summary>
    /// Запрос на получение альбома по айди
    /// </summary>
    public class GetAlbumByIdQuery : IRequest<Album>
    {
        /// <summary>
        /// Айди альбома
        /// </summary>
        public readonly Guid AlbumId;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GetAlbumByIdQuery(Guid albumId)
        {
            this.AlbumId = albumId;
        }
    }
}
