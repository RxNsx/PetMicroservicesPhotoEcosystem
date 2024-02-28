namespace PhotoEcosystem.ImageService.Dtos.Photos
{
    /// <summary>
    /// Модель для обновления фото
    /// </summary>
    public class PhotoUpdateDto
    {
        /// <summary>
        /// Айди
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Приватная
        /// </summary>
        public bool IsPrivate { get; set; }
        /// <summary>
        /// Отмеченная
        /// </summary>
        public bool IsFavourite { get; set; }
        /// <summary>
        /// Количество лайков
        /// </summary>
        public int LikesCount { get; set; }
        /// <summary>
        /// Альбом фотографии
        /// </summary>
        public Guid? AlbumId { get; set; }
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
