using PhotoEcosystem.ImageService.Models;

namespace PhotoEcosystem.ImageService.Dtos
{
    /// <summary>
    /// Модель для создания фото
    /// </summary>
    public class PhotoCreateDto
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
    }
}
