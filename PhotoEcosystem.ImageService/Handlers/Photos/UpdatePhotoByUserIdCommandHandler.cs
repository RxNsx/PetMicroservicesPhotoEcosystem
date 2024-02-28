using MediatR;
using PhotoEcosystem.ImageService.Commands.Photos;
using PhotoEcosystem.ImageService.Interfaces;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Handlers.Photos
{
    /// <summary>
    /// Обработчик команды обновления фотографии
    /// </summary>
    public class UpdatePhotoByUserIdCommandHandler : IRequestHandler<UpdatePhotoByUserIdCommand, Photo>
    {
        /// <summary>
        /// Репозиторий фотографий
        /// </summary>
        private readonly IPhotoRepository _photoRepository;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UpdatePhotoByUserIdCommandHandler(IPhotoRepository photoRepository)
        {
            _photoRepository = photoRepository;
        }

        /// <summary>
        /// Обработчик команды обновления фото
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Photo> Handle(UpdatePhotoByUserIdCommand request, CancellationToken cancellationToken)
        {
            var photo = request.Photo;
            var userId = request.UserId;
            return await _photoRepository.UpdatePhotoAsync(userId, photo);
        }
    }
}
