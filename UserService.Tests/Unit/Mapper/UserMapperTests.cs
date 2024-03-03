using AutoMapper;
using PhotoEcosystem.UserService.Dtos.Users;
using PhotoEcosystem.UserService.Models;
using PhotoEcosystem.UserService.Profiles;
using System.ComponentModel.DataAnnotations;
using UserService.Tests.Mocks;
using Xunit;

namespace UserService.Tests.Unit.Mapper
{
    /// <summary>
    /// Тесты маппинга пользователя
    /// </summary>
    public class UserMapperTests
    {
        /// <summary>
        /// Маппер
        /// </summary>
        private readonly IMapper _mapper;

        /// <summary>
        /// Конструктор
        /// </summary>
        public UserMapperTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });
            _mapper = mapperConfig.CreateMapper();
        }

        /// <summary>
        /// Маппинг пользователя из UserCreateDto в User
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void UserCreateDto_ShouldMapTo_User_WhenCreateUserIsValid()
        {
            //Arrange
            var userCreateDto = MockData.ValidCreateUserDto;

            //Act
            var user = _mapper.Map<User>(userCreateDto);

            //Assert
            Assert.Equal(userCreateDto.Login, user.Login);
        }

        [Theory]
        [MemberData(nameof(MockData.InvalidUserCreateDtoData), MemberType = typeof(MockData))]
        public void UserCreateDto_ShouldThrowException_WhenMapToUser(string login, string password, string confirmPassword, string email)
        {
            //Arrange
            var userCreateDto = new UserCreateDto()
            {
                Login = login,
                Password = password,
                ConfirmPassword = confirmPassword,
                Email = email
            };

            //Act + Assert
            Assert.ThrowsAny<Exception>(() => _mapper.Map<User>(userCreateDto));
        }

        /// <summary>
        /// Маппинг из пользователя для чтения в пользователя
        /// </summary>
        /// <returns></returns>
        [Fact]
        public void User_ShouldMapTo_UserReadDto_WhenUserIsValid()
        {
            //Arrange
            var user = MockData.ValidUser;

            //Act
            var userReadDto = _mapper.Map<UserReadDto>(user);

            //Assert
            Assert.Equal(user.Login, userReadDto.Login);
        }
    }
}
