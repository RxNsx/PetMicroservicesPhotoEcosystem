using MediatR;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Albums;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик запроса альбома по айдишнику
    /// </summary>
    public class GetAlbumByIdQueryHandler : IRequestHandler<GetAlbumByIdQuery, Album>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public GetAlbumByIdQueryHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Album> Handle(GetAlbumByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAlbumByIdAsync(request.AlbumId);
        }
    }
}