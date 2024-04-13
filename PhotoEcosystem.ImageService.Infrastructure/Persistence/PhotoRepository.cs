using PhotoEcosystem.ImageService.Application.Abstractions.Data;
using PhotoEcosystem.ImageService.Domain.Entities;

namespace PhotoEcosystem.ImageService.Infrastructure.Persistence;

public class PhotoRepository : IPhotoRepository
{
    public Task AddAsync(Guid userId, Photo photo)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid photoId, Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<Photo> GetPhotoByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Photo> UpdatePhotoAsync(Guid userId, Photo photo)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsPhotoExistsAsync(Guid userId, string name)
    {
        throw new NotImplementedException();
    }

    public Task<List<Photo>> GetAllPhotoByUserIdAsync(Guid userId)
    {
        throw new NotImplementedException();
    }

    public Task<List<Photo>> GetAllAsync()
    {
        throw new NotImplementedException();
    }
}