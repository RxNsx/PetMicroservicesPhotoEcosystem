using MediatR;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Albums;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик запроса на получение альбомов
    /// </summary>
    public class GetAllAlbumsQueryHandler : IRequestHandler<GetAllAlbumsQuery, List<Album>>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public GetAllAlbumsQueryHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<List<Album>> Handle(GetAllAlbumsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAlbumsAsync();
        }
    }
}