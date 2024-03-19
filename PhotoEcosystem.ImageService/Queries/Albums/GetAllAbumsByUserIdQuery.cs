using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Queries.Albums
{
    /// <summary>
    /// Команда запроса на получение альбомов
    /// </summary>
    public class GetAllAbumsByUserIdQuery : IRequest<List<Album>>
    {
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public readonly Guid UserId;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userId"></param>
        public GetAllAbumsByUserIdQuery(Guid userId)
        {
            this.UserId = userId;
        }
    }
}