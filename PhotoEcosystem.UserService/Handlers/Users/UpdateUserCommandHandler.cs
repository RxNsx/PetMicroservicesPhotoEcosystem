using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, User>
    {
        private readonly IUserRepository _repository;

        public UpdateUserCommandHandler(IUserRepository repository)
        {
            this._repository = repository;
        }

        public async Task<User> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateUserAsync(request.User);
        }
    }
}
