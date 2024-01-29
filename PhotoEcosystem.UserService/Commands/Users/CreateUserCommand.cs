using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Commands.Users
{
    /// <summary>
    /// Обработчик команды для создания пользователя
    /// </summary>
    public class CreateUserCommand : IRequest<User>
    {
        /// <summary>
        /// Форма созданя пользователя
        /// </summary>
        public readonly User User;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="user"></param>
        public CreateUserCommand(User user)
        {
            this.User = user;
        }
    }
}
