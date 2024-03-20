using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.ImageService.Commands.Albums;
using PhotoEcosystem.ImageService.Dtos.Albums;
using PhotoEcosystem.ImageService.Models;
using PhotoEcosystem.ImageService.Queries.Albums;

namespace PhotoEcosystem.ImageService.Controllers
{
    /// <summary>
    /// Контроллер для управления альбомами
    /// </summary>
    [ApiController]
    [Route("/api/albums")]
    public class AlbumController : ControllerBase
    {
        private readonly ILogger<AlbumController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// Конуструктор
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="mediator"></param>
        /// <param name="mapper"></param>
        public AlbumController(ILogger<AlbumController> logger, IMediator mediator, IMapper mapper)
        {
            this._logger = logger;
            this._mediator = mediator;
            this._mapper = mapper;
        }

        /// <summary>
        /// Запрос всех альбомов по пользователю
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("album/user/{userId:guid}")]

        public async Task<IActionResult> GetAllAlbumsByUserIdAsync(Guid userId)
        {
            _logger.LogInformation($"Запрос альбомов по указанному пользователю");
            var query = new GetAllAbumsByUserIdQuery(userId);
            var result = await _mediator.Send(query, default);
            var albums = _mapper.Map<AlbumReadDto>(result);
            return Ok(albums);
        }

        /// <summary>
        /// Получение альбома по пользователю
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("album/{albumId:guid}")]
        public async Task<IActionResult> GetAlbumByIdAsync(Guid albumId)
        {
            _logger.LogInformation($"Запрос альбома по айди");
            var query = new GetAlbumByIdQuery(albumId);
            var result = await _mediator.Send(query, default);
            if(result is null)
            {
                return NotFound();
            }
            var album = _mapper.Map<AlbumReadDto>(result);
            return Ok(album);
        }

        /// <summary>
        /// Получение всех альбомов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllAlbumsAsync()
        {
            _logger.LogInformation($"Запрос всех альбомов");
            var query = new GetAllAlbumsQuery();
            var result = await _mediator.Send(query, default);
            var albums = _mapper.Map<List<AlbumReadDto>>(result);
            return Ok(albums);
        }

        /// <summary>
        /// Добавление альбома
        /// </summary>
        /// <param name="albumCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateAlbumAsync")]
        public async Task<IActionResult> CreateAlbumAsync(AlbumCreateDto albumCreateDto)
        {
            _logger.LogInformation($"Создание альбома c названием {albumCreateDto}");
            var album = _mapper.Map<Album>(albumCreateDto);
            var command = new CreateAlbumCommand(album);
            var result = await _mediator.Send(command, default);
            if (result is null)
            {
                return BadRequest();
            }
            return CreatedAtRoute(nameof(CreateAlbumAsync), new { result.Name });
        }

        /// <summary>
        /// Обновление информации альбома
        /// </summary>
        /// <param name="albumUpdateDto"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateAlbumAsync(AlbumUpdateDto albumUpdateDto)
        {
            _logger.LogInformation($"Обновление альбома с названием {albumUpdateDto.Name}");
            var album = _mapper.Map<Album>(albumUpdateDto);
            var command = new UpdateAlbumCommand(album);
            var result = await _mediator.Send(command, default);
            if(result is null)
            {
                return BadRequest();
            }
            var updatedAlbum = _mapper.Map<Album>(result);
            return Ok(updatedAlbum);
        }

        /// <summary>
        /// Удаление альбома по айдишнику
        /// </summary>
        /// <param name="albumId"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("album/{albumId:guid}")]
        public async Task<IActionResult> RemoveAlbumAsync(Guid albumId)
        {
            _logger.LogInformation($"Удаление альбома по Id:{albumId}");
            var command = new RemoveAlbumCommand(albumId);
            await _mediator.Send(command, default);
            return NoContent();
        }
    }
}
