using MediatR;
using PhotoEcosystem.ImageService.Commands.Albums;
using PhotoEcosystem.ImageService.Interfaces;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик команды удаления альбома
    /// </summary>
    public class RemoveAlbumCommandHandler : IRequestHandler<RemoveAlbumCommand>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public RemoveAlbumCommandHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(RemoveAlbumCommand request, CancellationToken cancellationToken)
        {
            await _repository.RemoveAlbumAsync(request.AlbumId);
        }
    }
}
