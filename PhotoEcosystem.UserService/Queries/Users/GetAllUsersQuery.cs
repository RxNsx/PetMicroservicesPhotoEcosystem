using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Queries.Users
{
    /// <summary>
    /// Запрос на получение всех пользователей
    /// </summary>
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
