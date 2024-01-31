namespace PhotoEcosystem.ImageService.Settings
{
    /// <summary>
    /// Настройки подключения к брокеру
    /// </summary>
    public class RabbitMqSettings
    {
        /// <summary>
        /// Адрес хоста
        /// </summary>
        public string Host { get; set; } = string.Empty;
        /// <summary>
        /// Порт
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// Логин для входа
        /// </summary>
        public string UserName { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
