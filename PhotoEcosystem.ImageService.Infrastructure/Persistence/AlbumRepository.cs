using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Aggregates.Album;
using PhotoEcosystem.ImageService.Domain.Aggregates.Albums;
using PhotoEcosystem.ImageService.Domain.Interfaces;

namespace PhotoEcosystem.ImageService.Infrastructure.Persistence;

public sealed class AlbumRepository : IAlbumRepository
{
    private readonly AppDbContext _context;

    public AlbumRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<AlbumAggregate> AddAlbumAsync(string name)
    {
        var newAlbum = new AlbumAggregate(Guid.NewGuid(), name);
        var album = await _context.AddAsync(newAlbum);
        return album.Entity;
    }

    public Task<AlbumAggregate> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}