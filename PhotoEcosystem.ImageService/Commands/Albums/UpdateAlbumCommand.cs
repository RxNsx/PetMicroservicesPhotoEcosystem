using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Commands.Albums
{
    /// <summary>
    /// Команда обновления альбома
    /// </summary>
    public class UpdateAlbumCommand : IRequest<Album>
    {
        /// <summary>
        /// Альбом для обновления
        /// </summary>
        public readonly Album Album;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UpdateAlbumCommand(Album album)
        {
            this.Album = album;
        }
    }
}
