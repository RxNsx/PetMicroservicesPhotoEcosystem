using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.Dtos.Albums
{
    /// <summary>
    /// Модель для создания альбома
    /// </summary>
    public class AlbumCreateDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Required]
        [Length(5, 20, ErrorMessage = "Длина имени альбома должна быть между {1} и {2} символами")]
        public string Name { get; set; } = string.Empty;
        /// <summary>
        /// Закрытый
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Идентификатор пользователя владельца альбома
        /// </summary>
        public Guid UserId { get; set; }
    }
}
