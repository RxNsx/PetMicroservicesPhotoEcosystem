using MediatR;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Queries.Users;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, User>
    {
        private readonly IUserRepository _repository;

        public GetUserByIdQueryHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<User> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetUserByIdAsync(request.Id);
        }
    }
}
