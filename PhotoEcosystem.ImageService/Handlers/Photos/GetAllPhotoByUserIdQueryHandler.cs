using MediatR;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Photos;

namespace PhotoEcosystem.ImageService.Handlers.Photos
{
    /// <summary>
    /// Обработчик команды запроса фотографий конкретного пользователя
    /// </summary>
    public class GetAllPhotoByUserIdQueryHandler : IRequestHandler<GetAllPhotoByUserIdQuery, List<Photo>>
    {
        /// <summary>
        /// Репозиторий фотографий
        /// </summary>
        private readonly IPhotoRepository _photoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="photoRepository"></param>
        public GetAllPhotoByUserIdQueryHandler(IPhotoRepository photoRepository)
        {
            this._photoRepository = photoRepository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<List<Photo>> Handle(GetAllPhotoByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _photoRepository.GetAllPhotoByUserIdAsync(request.UserId);
        }
    }
}
