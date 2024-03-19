using MediatR;
using PhotoEcosystem.ImageService.Commands.Albums;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик команды добавления альбома
    /// </summary>
    public class CreateAlbumCommandHandler : IRequestHandler<CreateAlbumCommand, Album>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public CreateAlbumCommandHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Album> Handle(CreateAlbumCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateAlbumByUserAsync(request.Album);
        }
    }
}
