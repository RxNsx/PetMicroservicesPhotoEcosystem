using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    /// <summary>
    /// Обработчик команды создания пользователя
    /// </summary>
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public CreateUserCommandHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик команды
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateUserAsync(request.User);
        }
    }
}
