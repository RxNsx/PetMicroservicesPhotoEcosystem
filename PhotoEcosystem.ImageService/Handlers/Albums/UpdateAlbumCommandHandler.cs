using MediatR;
using PhotoEcosystem.ImageService.Commands.Albums;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик команды обновления альбома
    /// </summary>
    public class UpdateAlbumCommandHandler : IRequestHandler<UpdateAlbumCommand, Album>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public UpdateAlbumCommandHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Album> Handle(UpdateAlbumCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAlbumAsync(request.Album);
        }
    }
}
