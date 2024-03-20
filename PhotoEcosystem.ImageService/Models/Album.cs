using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.Models;

/// <summary>
/// Модель альбома
/// </summary>
public class Album
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// Название
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
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// Список фотографий в альбоме
    /// </summary>
    public  ICollection<Photo> Photos { get; set; } = new List<Photo>();
}