using Shared.Primitives;

namespace PhotoEcosystem.ImageService.Domain.Entities;

public class Album : Entity<Guid>
{
    /// <summary>
    /// Название альбома
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// Закрытый
    /// </summary>
    public bool IsPrivate { get; set; }
    /// <summary>
    /// Отмеченный
    /// </summary>
    public bool IsFavourite { get; set; }
    /// <summary>
    /// Количество лайков
    /// </summary>
    public int LikesCount { get; set; }
    /// <summary>
    /// Идентификатор пользователя владельца альбома
    /// </summary>
    public Guid UserId { get; set; }
    //TODO: Доделать
    /// <summary>
    /// Модель пользователя
    /// </summary>
    // public User User { get; set; }
    /// <summary>
    /// Список фотографий в альбоме
    /// </summary>
    public  ICollection<Photo> Photos { get; set; } = new List<Photo>();
}