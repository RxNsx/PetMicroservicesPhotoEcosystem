using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    /// <summary>
    /// Обработчик команды удаления пользователя
    /// </summary>
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public DeleteUserByIdCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Обработчик команды удаления пользователя
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserAsync(request.Id);
        }
    }
}
