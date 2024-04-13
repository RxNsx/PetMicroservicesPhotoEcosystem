using Shared.Primitives;

namespace PhotoEcosystem.ImageService.Domain.Entities;

public class Photo : Entity<Guid>
{
    /// <summary>
    /// Название
    /// </summary>
    public string PhotoName { get; set; }
    /// <summary>
    /// Закрытая?
    /// </summary>
    public bool IsPrivate { get; set; }
    /// <summary>
    /// Лайк
    /// </summary>
    public bool IsFavourite { get; set; }
    /// <summary>
    /// Количество лайков
    /// </summary>
    public int LikesCount { get; set; }

    private Photo()
    {
    }
    
    private Photo(string photoName)
    {
        PhotoName = photoName;
        IsPrivate = false;
        LikesCount = 0;
        IsFavourite = false;
    }
}