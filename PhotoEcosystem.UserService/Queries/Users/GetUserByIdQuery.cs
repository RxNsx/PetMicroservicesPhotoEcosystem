using MediatR;
using Npgsql.Replication;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Queries.Users
{
    public class GetUserByIdQuery : IRequest<User>
    {
        public readonly Guid Id;

        public GetUserByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
