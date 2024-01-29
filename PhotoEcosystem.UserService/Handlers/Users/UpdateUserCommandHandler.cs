using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    /// <summary>
    /// Обработчик команды обновления пользователя
    /// </summary>
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public UpdateUserCommandHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик команды обновления пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUserAsync(request.User);
        }
    }
}
