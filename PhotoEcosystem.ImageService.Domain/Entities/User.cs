using Shared.Primitives;

namespace PhotoEcosystem.ImageService.Domain.Entities;

public class User : Entity<Guid>
{
    /// <summary>
    /// Внешний айди из сервиса пользователей
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
    public ICollection<Album> Albums { get; set; } = new List<Album>();
}