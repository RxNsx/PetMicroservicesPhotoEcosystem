using MediatR;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Queries.Users;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    /// <summary>
    /// Обработчик получения всех пользователей
    /// </summary>
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        /// <summary>
        /// Репозиторий пользоваелей
        /// </summary>
        private readonly IUserRepository _repository;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="repository"></param>
        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        /// <summary>
        /// Обработчик получения всех пользователей
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllUsersAsync();
            throw new NotImplementedException();
        }
    }
}
