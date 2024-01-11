using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Commands.Users
{
    public class UpdateUserCommand : IRequest<User>
    {
        public readonly User User;

        public UpdateUserCommand(User user)
        {
            this.User = user;
        }
    }
}
