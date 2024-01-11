using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Queries.Users;

namespace PhotoEcosystem.UserService.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UserController(ILogger<UserController> logger, IMediator mediator, IMapper mapper)
        {
            this._logger = logger;
            this._mediator = mediator;
            this._mapper = mapper;
        }

        /// <summary>
        /// Получение всех пользователей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<UserReadDto>>> GetAllUsersAsync()
        {
            var query = new GetAllUsersQuery();
            var result =  await _mediator.Send(query);
            return _mapper.Map<List<UserReadDto>>(result);
        }

        /// <summary>
        /// Создание пользователя
        /// </summary>
        /// <param name="userCreateDto"></param>
        /// <returns></returns>
        [HttpPost(Name = "CreateUserAsync")]
        public async Task<ActionResult> CreateUserAsync([FromBody]UserCreateDto userCreateDto)
        {
            var user = _mapper.Map<User>(userCreateDto);
            var command = new CreateUserCommand(user);
            var result = await _mediator.Send(command);

            if(result is null)
            {
                return BadRequest();
            }

            var userReadDto = _mapper.Map<UserReadDto>(result);
            return CreatedAtRoute(nameof(CreateUserAsync), new { Id = result.Id}, userReadDto);
        }

        /// <summary>
        /// Получение пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<ActionResult<UserReadDto>> GetUserByIdAsync(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = await _mediator.Send(query);

            if(result is null)
            {
                return NotFound(new { Id = id });
            }

            return _mapper.Map<UserReadDto>(result);
        }

        /// <summary>
        /// Обновление пользователя
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<ActionResult> UpdateUserAsync([FromBody]UserReadDto updateUser)
        {
            var updatedUser = _mapper.Map<User>(updateUser);
            var command = new UpdateUserCommand(updatedUser);
            var result = await _mediator.Send(command);

            if (result is null)
            {
                return NotFound(new { Id = updateUser.Id });
            }

            return Ok(result);
        }

        /// <summary>
        /// Удаление пользователя по Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteUserById(Guid id)
        {
            var command = new DeleteUserByIdCommand(id);
            await _mediator.Send(command);
            return Ok(command.Id);
        }
    }
}
