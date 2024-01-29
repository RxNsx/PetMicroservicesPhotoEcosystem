using MediatR;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Queries.Users;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    /// <summary>
    /// Обработчик запроса пользователя по идентификатору
    /// </summary>
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        /// <summary>
        /// Репозиторий пользователей
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик запроса пользователя по идентификатору
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByIdAsync(request.Id);
        }
    }
}
