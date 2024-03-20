using MediatR;
using PhotoEcosystem.ImageService.Commands.Photos;
using PhotoEcosystem.ImageService.Interfaces;

namespace PhotoEcosystem.ImageService.Handlers.Photos
{
    /// <summary>
    /// Обработчик добавления фотографии польщователя
    /// </summary>
    public class AddPhotoByUserIdCommandHandler : IRequestHandler<AddPhotoByUserIdCommand>
    {
        /// <summary>
        /// Репозиторий управления фотографиями
        /// </summary>
        private readonly IPhotoRepository _photoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="photoRepository"></param>
        public AddPhotoByUserIdCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        /// <summary>
        /// Обработчик команды добавления фотографии
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(AddPhotoByUserIdCommand request, CancellationToken cancellationToken)
        {
            var userId = request.UserId;
            var photo = request.Photo;
            await _photoRepository.AddAsync(userId, photo);
        }
    }
}