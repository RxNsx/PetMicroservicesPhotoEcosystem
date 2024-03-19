using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Commands.Albums
{
    /// <summary>
    /// Команда на создание альбома
    /// </summary>
    public class CreateAlbumCommand : IRequest<Album>
    {
        /// <summary>
        /// Создаваемый альбом
        /// </summary>
        public readonly Album Album;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="album"></param>
        public CreateAlbumCommand(Album album)
        {
            this.Album = album;
        }
    }
}
