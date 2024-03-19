using MediatR;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Albums;

namespace PhotoEcosystem.ImageService.Handlers.Albums
{
    /// <summary>
    /// Обработчик на запросв альбомов по пользователю
    /// </summary>
    public class GetAllAbumsByUserIdQueryHandler : IRequestHandler<GetAllAbumsByUserIdQuery, List<Album>>
    {
        private readonly IAlbumRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GetAllAbumsByUserIdQueryHandler(IAlbumRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<Album>> Handle(GetAllAbumsByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllByUserIdAsync(request.UserId);
        }
    }
}
