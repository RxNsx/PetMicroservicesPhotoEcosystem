namespace PhotoEcosystem.ImageService.Dtos.Photos
{
    /// <summary>
    /// Модель для чтения фото
    /// </summary>
    public class PhotoReadDto
    {
        /// <summary>
        /// Айди фото
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
        /// Выбранная
        /// </summary>
        public bool IsFavourite { get; set; }
        /// <summary>
        /// Количество лайков
        /// </summary>
        public int LikesCount { get; set; }
        /// <summary>
        /// Айди альбома
        /// 
        /// </summary>
        public Guid? AlbumId { get; set; }
        /// <summary>
        /// Айди пользователя
        /// </summary>
        public Guid UserId { get; set; }
    }
}
