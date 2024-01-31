namespace PhotoEcosystem.ImageService.Dtos
{
    /// <summary>
    /// Модель для чтения фото
    /// </summary>
    public class PhotoReadDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public int LikesCount { get; set; }
    }
}
