using MediatR;

namespace PhotoEcosystem.ImageService.Commands.Albums
{
    /// <summary>
    /// Команда на удаление альбома
    /// </summary>
    public class RemoveAlbumCommand : IRequest
    {
        /// <summary>
        /// Айди альбома на удаление
        /// </summary>
        public readonly Guid AlbumId;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RemoveAlbumCommand(Guid albumId)
        {
            this.AlbumId = albumId;
        }
    }
}
