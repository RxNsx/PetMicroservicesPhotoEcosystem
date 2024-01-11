using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public CreateUserCommandHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.CreateUserAsync(request.User);
        }
    }
}
