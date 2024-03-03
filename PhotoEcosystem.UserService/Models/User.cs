using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace PhotoEcosystem.UserService.Models
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        private const int MinimumLength = 5;
        private const int MaximumLength = 15;

        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; private set; }
        /// <summary>
        /// Логин
        /// </summary>
        [Required]
        [Length(MinimumLength, MaximumLength, ErrorMessage = "Error length must be between {1} and {2} symbols")]
        public string Login { get; private set; }
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; private set; }
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
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
        /// Конструктор с логином паролем и почтой
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        public User(string login, string password, string email)
        {
            if(string.IsNullOrEmpty(login))
            {
                throw new ArgumentNullException(nameof(login));
            }
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException(nameof(password));
            }
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentNullException(nameof(email));
            }
            if (!IsLengthCorrect(login))
            {
                throw new ArgumentException($"{nameof(login)} недопустимая длина логина");
            }
            if (!IsLengthCorrect(password))
            {
                throw new ArgumentException($"{nameof(password)} недопустимая длина пароля");
            }
            if (!IsEmailCorrect(email))
            {
                throw new ArgumentException($"{nameof(email)} Недопустимый адрес почты");
            }

            this.Login = login;
            this.Password = password;
            this.Email = email;
            this.Status = UserStatus.Active;
            this.LastTimeOnline = DateTime.UtcNow;
        }

        /// <summary>
        /// Установка имени пользователя
        /// </summary>
        /// <param name="login"></param>
        public void SetLogin(string login)
        {
            if (!IsLengthCorrect(login))
            {
                throw new ArgumentException($"Недопустимая длина {nameof(login)}");
            }

            Login = login;
        }

        /// <summary>
        /// Установка пароля пользователя
        /// </summary>
        /// <param name="password"></param>
        public void SetPassword(string password)
        {
            if (!IsLengthCorrect(password))
            {
                throw new ArgumentException($"{nameof(password)} недопустимая длина пароля");
            }

            Password = password;
        }

        /// <summary>
        /// Установка почты пользователя
        /// </summary>
        /// <param name="email"></param>
        public void SetEmail(string email)
        {
            if (!IsEmailCorrect(email))
            {
                throw new ArgumentException($"Недопустимый адрес почты: {email}");
            }

            Email = email;
        }

        /// <summary>
        /// Проверка длины нужной строки на соответсвие требованиям системы
        /// </summary>
        /// <param name="dataString"></param>
        /// <returns></returns>
        private bool IsLengthCorrect(string dataString)
        {
            return (dataString.Length >= MinimumLength && dataString.Length <= MaximumLength);
        }

        /// <summary>
        /// Проверка корректности почты
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        private bool IsEmailCorrect(string email)
        {
            Regex regex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
            return regex.IsMatch(email);

        }
    }
}
