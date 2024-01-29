namespace PhotoEcosystem.UserService.Dtos.Users
{
    /// <summary>
    /// Модель для создания пользователя
    /// </summary>
    public class UserCreateDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Login { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Почта
        /// </summary>
        public string Email { get; set; } = string.Empty;
    }
}
