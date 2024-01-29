using MediatR;
using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Commands.Users
{
    /// <summary>
    /// Команда на обновление пользователя
    /// </summary>
    public class UpdateUserCommand : IRequest<User>
    {
        /// <summary>
        /// Модель пользователя для обновления
        /// </summary>
        public readonly User User;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="user"></param>
        public UpdateUserCommand(User user)
        {
            this.User = user;
        }
    }
}
