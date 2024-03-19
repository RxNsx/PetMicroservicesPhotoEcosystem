using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.Dtos.Albums
{
    /// <summary>
    /// Модель для обновления альбома
    /// </summary>
    public class AlbumUpdateDto
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
        [Required]
        public bool IsPrivate { get; set; }
    }
}
