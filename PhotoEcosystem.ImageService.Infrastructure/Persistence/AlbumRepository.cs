using Microsoft.EntityFrameworkCore;
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
        var album = await _context.Albums.AddAsync(newAlbum);
        return album.Entity;
    }

    public async Task<AlbumAggregate> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Albums.FirstOrDefaultAsync(a => a.Id == id, cancellationToken);
    }

    public async Task<bool> RemoveAsync(Guid id, CancellationToken cancellationToken)
    {
        var album = await GetByIdAsync(id, cancellationToken);
        if (album is null)
        {
            return false;
        }
        
        return _context.Albums.Remove(album).State == EntityState.Deleted;
    }
}