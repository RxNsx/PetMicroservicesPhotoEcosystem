using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;

namespace UserService.Tests.Mocks
{
    /// <summary>
    /// Тестовые данные
    /// </summary>
    public static class MockData
    {
        /// <summary>
        /// Валидный пользователь
        /// </summary>
        public static User ValidUser => new User("testuserlogin", "password123", "testuseremail@mail.ru");
        public static UserCreateDto ValidCreateUserDto => new UserCreateDto()
        {
            Login = "testuserlogin",
            Password = "password123",
            ConfirmPassword = "password123",
            Email = "testuseremail@mail.ru"
        };

        /// <summary>
        /// Невалидные варианты данных для пользователя
        /// </summary>
        public static IEnumerable<object[]> InvalidUserData()
        {
            return new List<object[]>()
            {
                new object[] { string.Empty, "password123", "user@example.com"},
                new object[] { "testuserlogin", "password123password123password123password123", "user@example.com"},
                new object[] { "testuserlogin", string.Empty, "user@example.com"},
                new object[] { "testuserlogin", "password123", string.Empty},
                new object[] { null, "password123", string.Empty},
                new object[] { null, null, string.Empty},
                new object[] { null, null, null}
            };
        }

        /// <summary>
        /// Невалидные варианты данных 
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> InvalidUserCreateDtoData()
        {
            return new List<object[]>()
            {
                new object[] { string.Empty, "password123", "password312", "user@example.com"},
                new object[] { "testuserlogin", "password123password123password123password123", "password123password112323password123password123", "user@example.com" },
                new object[] { "testuserlogin", string.Empty, string.Empty, "user@example.com"},
                new object[] { "testuserlogin", "password123", null, string.Empty},
                new object[] { null, null, "password123", string.Empty},
                new object[] { null, null, null, string.Empty},
                new object[] { null, null, null, null}
            };
        }
    }
}
