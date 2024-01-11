using MediatR;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Queries.Users;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<User>>
    {
        private readonly IUserRepository _repository;

        public GetAllUsersQueryHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public Task<List<User>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return _repository.GetAllUsersAsync();
            throw new NotImplementedException();
        }
    }
}
