using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Commands.Users
{
    public class CreateUserCommand : IRequest<User>
    {
        public readonly User User;

        public CreateUserCommand(User user)
        {
            this.User = user;
        }
    }
}
