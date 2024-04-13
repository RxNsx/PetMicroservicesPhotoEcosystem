using PhotoEcosystem.ImageService.Domain.Aggregates.Album;
using PhotoEcosystem.ImageService.Domain.Entities;
using Shared.Primitives;

namespace PhotoEcosystem.ImageService.Domain.Aggregates.Albums;

public class AlbumAggregate : AggregateRoot<Guid>
{
    private AlbumAggregate() { }
    
    private readonly List<Photo> _photos = new();
    public AlbumName AlbumName { get; private set; }
    public IReadOnlyCollection<Photo> Photos => _photos;
    
    public AlbumAggregate(Guid id, string name) : base(id)
    {
        AlbumName = AlbumName.Create(name).Value;
    }

    public void ModifyAlbumName(string name)
    {
        AlbumName = AlbumName.Create(name).Value;
    }

    public void RemovePhoto(Photo photo)
    {
        _photos.Remove(photo);
    }

    public void AddPhoto(Photo photo)
    {
        _photos.Add(photo);
    }

    public void UpdatePhoto(Photo updateTo)
    {
        var updatePhoto = _photos.SingleOrDefault(updateTo);
        _photos.Remove(updatePhoto);

        updatePhoto.PhotoName = updatePhoto.PhotoName;
        updatePhoto.IsFavourite = updateTo.IsFavourite;
        updatePhoto.LikesCount = updateTo.LikesCount;
        updatePhoto.IsPrivate = updateTo.IsPrivate;
        _photos.Add(updatePhoto);
    }
}