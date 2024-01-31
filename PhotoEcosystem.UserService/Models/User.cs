using System.ComponentModel.DataAnnotations;

namespace PhotoEcosystem.UserService.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; private set; }
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        public string Login { get; private set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        public string Password { get; private set; }
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        public string Email { get; private set; }
        /// <summary>
        /// Статус пользователя
        /// </summary>
        public UserStatus Status { get; private set; }
        /// <summary>
        /// Последнее время онлайн
        /// </summary>
        public DateTime LastTimeOnline { get; private set; }

        /// <summary>
        /// Конструктор с логином и паролем
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
            this.Status = UserStatus.Active;
            this.LastTimeOnline = DateTime.UtcNow;
            this.Email = string.Empty;
        }

        /// <summary>
        /// Конструктор с логином паролем и почтой
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public User(string login, string password, string email) : this(login, password)
        {
            this.Email = email;   
        }

        /// <summary>
        /// Установка имени пользователя
        /// </summary>
        /// <param name="login"></param>
        public void SetLogin(string login)
        {
            Login = login;
        }

        /// <summary>
        /// Установка пароля пользователя
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            Password = password;
        }
        
        /// <summary>
        /// Установка почты пользователя
        /// </summary>
        /// <param name="email"></param>
        public void SetEmail(string email)
        {
            Email = email;
        }
    }
}
