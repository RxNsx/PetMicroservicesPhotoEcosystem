using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Dtos.Photos
{
    /// <summary>
    /// Модель для создания фото
    /// </summary>
    public class PhotoCreateDto
    {
        /// <summary>
        /// Название фотографии
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приватная
        /// </summary>
        public bool IsPrivate { get; set; }
    }
}
