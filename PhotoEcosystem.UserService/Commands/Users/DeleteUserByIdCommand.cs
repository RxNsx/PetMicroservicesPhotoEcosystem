using MediatR;

namespace PhotoEcosystem.UserService.Commands.Users
{
    /// <summary>
    /// Команда удаления пользователя
    /// </summary>
    public class DeleteUserByIdCommand : IRequest
    {
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public readonly Guid Id;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="id"></param>
        public DeleteUserByIdCommand(Guid id)
        {
            this.Id = id;
        }
    }
}
