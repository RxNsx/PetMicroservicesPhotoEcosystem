using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.ImageService.Commands.Photos;
using PhotoEcosystem.ImageService.Dtos.Photos;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Photos;

namespace PhotoEcosystem.ImageService.Controllers
{
    /// <summary>
    /// Контроллер для управления фотографиями
    /// </summary>
    [ApiController]
    [Route("/api/photos")]
    public class PhotoController : ControllerBase
    {
        private readonly ILogger<PhotoController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public PhotoController(ILogger<PhotoController> logger, IMediator mediator, IMapper mapper)
        {
            this._logger = logger;
            this._mediator = mediator;
            this._mapper = mapper;
        }

        /// <summary>
        /// Получение всех фотографий по пользователю
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/user/{userId:guid}")]
        public async Task<IActionResult> GetPhotosByUserId(Guid userId)
        {
            var request = new GetAllPhotoByUserIdQuery(userId);
            var result = await _mediator.Send(request, default);
            _logger.LogInformation($"Получено фотографий по пользователю: {userId} Количество: {result.Count}");
            return Ok(_mapper.Map<List<PhotoReadDto>>(result));
        }

        /// <summary>
        /// Добавление фотографии пользователю
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="photoCreateDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/user/{userId:guid}")]
        public async Task<IActionResult> AddPhotoByUserId(Guid userId, PhotoCreateDto photoCreateDto)
        {
            _logger.LogInformation($"Добавление фотографии пользователю: {userId} с названием: {photoCreateDto.Name}");
            var photo = _mapper.Map<Photo>(photoCreateDto);
            var command = new AddPhotoByUserIdCommand(userId, photo);
            await _mediator.Send(command, default);
            return CreatedAtAction("AddPhotoByUserId", new { name = photoCreateDto.Name });
        }

        /// <summary>
        /// Обновление фото у пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="photoUpdate"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("user/{userId:guid}/photo")]
        public async Task<IActionResult> UpdatePhotoByUserId(Guid userId, PhotoUpdateDto photoUpdate)
        {
            _logger.LogInformation($"Обновлении информации фотографии: {photoUpdate.Name} у пользователя: {userId}");
            var photo = _mapper.Map<Photo>(photoUpdate);
            var command = new UpdatePhotoByUserIdCommand(userId, photo);
            var result = await _mediator.Send(command, default);
            return Ok(result);
        }

        /// <summary>
        /// Удаление фото у пользователя
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="photoId"></param>
        /// <returns></returns>

        [HttpDelete]
        [Route("user/{userId:guid}/photo/{photoId:guid}")]
        public async Task<IActionResult> RemovePhotoById(Guid userId, Guid photoId)
        {
            _logger.LogInformation($"Удаление фотографии у пользователя: {userId} Id: {photoId}");
            var command = new RemovePhotoByUserIdCommand(photoId, userId);
            await _mediator.Send(command, default);
            return NoContent();
        }

        /// <summary>
        /// Получение фотографии по айди
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{photoId:guid}")]
        public async Task<IActionResult> GetPhotoById(Guid photoId)
        {
            _logger.LogInformation($"Получение фото по Id:{photoId}");
            var query = new GetPhotoByIdQuery(photoId);
            var result = await _mediator.Send(query, default);
            var photo = _mapper.Map<PhotoReadDto>(result);
            return Ok(result);
        }
    }
}