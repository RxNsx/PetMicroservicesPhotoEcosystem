using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Interfaces;
using Shared;

namespace PhotoEcosystem.ImageService.Domain.DomainServices.Album;

public sealed class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _repository;

    public AlbumService(IAlbumRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<Result> AddAlbum(string name)
    {
        var album = await _repository.AddAlbumAsync(name);
        if (album is null)
        {
            return Result.Failure(Error.NullValue);
        }
        return Result.Success();
    }
}