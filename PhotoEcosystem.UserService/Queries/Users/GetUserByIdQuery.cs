using MediatR;
using Npgsql.Replication;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Queries.Users
{
    /// <summary>
    /// Команда запроса пользователя по идентификатору
    /// </summary>
    public class GetUserByIdQuery : IRequest<User>
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public readonly Guid Id;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        public GetUserByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
