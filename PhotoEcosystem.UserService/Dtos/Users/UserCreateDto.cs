using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

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
        [Required]
        [Length(5, 15, ErrorMessage = "Логин не меньше чем {1} и не больше чем {2} символов")]
        public string Login { get; set; } = string.Empty;
        /// <summary>
        /// Пароль
        /// </summary>
        [Required]
        [Length(5, 15, ErrorMessage = "Пароль не меньше чем {1} и не больше чем {2} символов")]
        public string Password { get; set; } = string.Empty;
        /// <summary>
        /// Подтверждение пароля
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [Length(5, 15, ErrorMessage = "Подтверждение пароля не меньше чем {1} и не больше чем {2} символов")]
        public string ConfirmPassword { get; set; } = string.Empty;
        /// <summary>
        /// Почта
        /// </summary>
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$")]
        public string Email { get; set; } = string.Empty;
    }
}
