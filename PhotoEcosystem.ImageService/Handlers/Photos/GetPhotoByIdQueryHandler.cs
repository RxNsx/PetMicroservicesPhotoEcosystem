using MediatR;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Photos;

namespace PhotoEcosystem.ImageService.Handlers.Photos
{
    /// <summary>
    /// Обработчик запроса на получение фото по айди
    /// </summary>
    public class GetPhotoByIdQueryHandler : IRequestHandler<GetPhotoByIdQuery, Photo>
    {
        /// <summary>
        /// Репозиторий для фотографий
        /// </summary>
        private readonly IPhotoRepository _photoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public GetPhotoByIdQueryHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        /// <summary>
        /// Обработчик запроса на получение фото по айди
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Photo> Handle(GetPhotoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _photoRepository.GetPhotoByIdAsync(request.PhotoId);
        }
    }
}
