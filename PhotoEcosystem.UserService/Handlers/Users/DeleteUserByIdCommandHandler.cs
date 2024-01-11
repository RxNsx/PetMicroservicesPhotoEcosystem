using MediatR;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Interfaces;

namespace PhotoEcosystem.UserService.Handlers.Users
{
    public class DeleteUserByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand>
    {
        private readonly IUserRepository _repository;

        public DeleteUserByIdCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteUserAsync(request.Id);
        }
    }
}
