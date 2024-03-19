using MediatR;
using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Queries.Albums
{
    /// <summary>
    /// Запрос на получение всех альбомов
    /// </summary>
    public class GetAllAlbumsQuery : IRequest<List<Album>>
    {

    }
}
