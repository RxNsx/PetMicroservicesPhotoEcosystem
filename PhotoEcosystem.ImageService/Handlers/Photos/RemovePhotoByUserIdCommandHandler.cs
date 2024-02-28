using MediatR;
using PhotoEcosystem.ImageService.Commands.Photos;
using PhotoEcosystem.ImageService.Interfaces;

namespace PhotoEcosystem.ImageService.Handlers.Photos
{
    /// <summary>
    /// Обработчик команды на удаление фотографии у пользователя
    /// </summary>
    public class RemovePhotoByUserIdCommandHandler : IRequestHandler<RemovePhotoByUserIdCommand>
    {
        /// <summary>
        /// Репозиторий фотографий
        /// </summary>
        private readonly IPhotoRepository _photoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public RemovePhotoByUserIdCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        /// <summary>
        /// Обработчик
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(RemovePhotoByUserIdCommand request, CancellationToken cancellationToken)
        {
            await _photoRepository.RemoveAsync(request.PhotoId, request.UserId);
        }
    }
}
