﻿using Microsoft.EntityFrameworkCore;
using PhotoEcosystem.UserService.Commands.Users;
using PhotoEcosystem.UserService.Models;
using UserService.Tests.Mocks;
using Xunit;

namespace UserService.Tests.Integration.Controllers
{
    /// <summary>
    /// Класс тестов для контроллера пользователей
    /// </summary>
    public class UserControllerTests : BaseIntegrationTest
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="factory"></param>
        public UserControllerTests(IntegrationTestWebAppFactory factory)
            : base(factory)
        {
        }

        /// <summary>
        /// Добавление пользователя в систему
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateUser_ShouldAdd_NewUserInDatabase_WhenUserIsValid()
        {
            //Arrange
            var user = MockData.ValidUser;
            var command = new CreateUserCommand(user);

            //Act
            var result = await Sender.Send(command);

            //Assert
            Assert.Equal(user.Login, result.Login);
        }

        /// <summary>
        /// Не должен быть создан дубликат пользователя
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateUser_ShouldNotAdd_NewUserInDatabase_WhenUserIsDuplicated()
        {
            //Arrange
            var user = MockData.ValidUser;
            var command = new CreateUserCommand(user);

            //Act
            await Sender.Send(command);
            var result = await Sender.Send(command);

            //Assert
            Assert.Null(result);
        }

        /// <summary>
        /// Создание пользователя командой, когда пользователь некорректный
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task CreateUser_ShouldNotAdd_NewUserInDatabase_WhenUserIsInvalid()
        {
            //Arrange
            var user = MockData.InvalidUserData().FirstOrDefault().FirstOrDefault() as User;
            var command = new CreateUserCommand(user);

            //Act + Assert
            await Assert.ThrowsAnyAsync<Exception>(() => Sender.Send(command));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetUserById_ShouldReturn_ValidUser()
        {
            //Arrange
            var user = await Context.Users.FirstOrDefaultAsync();


        }
    }
}
