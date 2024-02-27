using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.Models;

/// <summary>
/// Модель фотографии \ картинки
/// </summary>
public class Photo
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }
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
    /// <summary>
    /// Айди альбома
    /// </summary>
    public Guid? AlbumId { get; set; }
    /// <summary>
    /// Альбом
    /// </summary>
    public Album? Album { get; set; }
    /// <summary>
    /// Идентификатор пользователя владельца альбома
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public User User { get; set; }
}