using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.Models;

/// <summary>
/// Модель пользователя
/// </summary>
public class User
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    [Key]
    public Guid Id { get; set; }
    /// <summary>
    /// Внешний ключ из сервиса пользователей
    /// </summary>
    public Guid ExternalId { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Почта
    /// </summary>
    public string Email { get; set; } = string.Empty;
    /// <summary>
    /// Последнее время онлайн UTC
    /// </summary>
    public DateTime LastTimeOnline { get; set; }
    /// <summary>
    /// Альбомы пользователя
    /// </summary>
    public List<Album> Albums { get; set; } = new List<Album>();
}