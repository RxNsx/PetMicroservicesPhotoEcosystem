using MediatR;

namespace PhotoEcosystem.UserService.Commands.Users
{
    public class DeleteUserByIdCommand : IRequest
    {
        public readonly Guid Id;

        public DeleteUserByIdCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
