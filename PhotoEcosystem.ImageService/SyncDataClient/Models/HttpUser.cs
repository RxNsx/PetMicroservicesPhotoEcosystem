using System;
using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.ImageService.SyncDataClient.Models
{
    /// <summary>
    /// Модель пользователя с UserService
    /// </summary>
    public class HttpUser
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
        public int Status { get; set; }
        /// <summary>
        /// Последнее время активности
        /// </summary>
        public DateTime LastTimeOnline { get; set; }
    }
}
