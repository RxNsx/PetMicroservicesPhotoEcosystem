namespace PhotoEcosystem.UserService.Models
{
    /// <summary>
    /// Статусы пользователей
    /// </summary>
    public enum UserStatus
    {
        /// <summary>
        /// Не в сети
        /// </summary>
        Offline,
        /// <summary>
        /// В сети
        /// </summary>
        Online,
        /// <summary>
        /// Активен
        /// </summary>
        Active,
        /// <summary>
        /// Забанен
        /// </summary>
        Banned,
        /// <summary>
        /// Заблокирован
        /// </summary>
        Blocked
    }
}
