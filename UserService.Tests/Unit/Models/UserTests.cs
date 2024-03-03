using PhotoEcosystem.UserService.Models;
using UserService.Tests.Mocks;
using Xunit;

namespace UserService.Tests.Unit.Models
{
    /// <summary>
    /// Тесты пользователя
    /// </summary>
    public class UserTests
    {
        /// <summary>
        /// Создание корректного пользователя из конструктора
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void User_ShouldBeCreated_WhenDataIsValid()
        {
            //Arrange + Act
            var sut = MockData.ValidUser;

            //Assert
            Assert.Equal(MockData.ValidUser.Login, sut.Login);
        }

        /// <summary>
        /// Ошибка если дата невалидная
        /// </summary>
        /// <returns></returns>
        [Theory]
        [MemberData(nameof(MockData.InvalidUserData), MemberType = typeof(MockData))]
        public void CreateUser_ShouldThrowException_WhenDataIsInvalid(string login, string password, string email)
        {
            Assert.ThrowsAny<Exception>(() => new User(login, password, email));
        }
    }
}
