using PhotoEcosystem.UserService.Models;

namespace PhotoEcosystem.UserService.Dtos.Users
{
    /// <summary>
    /// Модель для чтения пользователя
    /// </summary>
    public class UserReadDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus Status { get; set; }
        /// <summary>
        /// Последнее время активности
        /// </summary>
        public DateTime LastTimeOnline { get; set; }
    }
}
