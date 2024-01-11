using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Queries.Users
{
    public class GetAllUsersQuery : IRequest<List<User>>
    {
    }
}
