using Shared;

namespace PhotoEcosystem.ImageService.Domain.DomainServices.Album;

public interface IAlbumService
{
    Task<Result> AddAlbum(string name);
}