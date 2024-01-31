using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.ImageService.Dtos;
using PhotoEcosystem.ImageService.Queries.Photos;

namespace PhotoEcosystem.ImageService.Controllers
{
    /// <summary>
    /// Контроллер для управления фотографиями
    /// </summary>
    [ApiController]
    [Route("/api/[controller]")]
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
        [Route("photos/user/{userId:guid}")]
        public async Task<IActionResult> GetPhotosByUserId(Guid userId)
        {
            var request = new GetAllPhotoByUserIdQuery(userId);
            var result = await _mediator.Send(request, default);
            _logger.LogInformation($"Получено фотографий по пользователю: {userId} Количество: {result.Count}");
            return Ok(_mapper.Map<List<PhotoReadDto>>(result));
        }
    }
}