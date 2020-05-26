using System;
using System.Collections.Generic;
using System.Text;
using Lobster.Core.Domain;
using Lobster.Data;
using Lobster.Server.Services.UserServices;
using Moq;
using Xunit;

namespace Lobster.Server.Services.Test.Users
{
    public class UserServiceTests
    {
        private readonly Mock<Repository<User>> _userRepositoryMock;

        public UserServiceTests()
        {
            _userRepositoryMock = new Mock<Repository<User>>();
        }

        [Fact]
        public void GetPublicUserDataTest()
        {
            //ARRANGE
            User user = new User
            {
                Id = 1,
                Email = "Test",
                EncryptionKey = "XYZ",
                Karma = 10,
                Password = "Password",
                Username = "TestUsername"
            };

            _userRepositoryMock.SetupRepositoryMock(options => { options.Insert(user); });

            var userService = new UserService(_userRepositoryMock.Object);

            //ACT
            var publicUser = userService.GetPublicUserData(1);

            //ASSERT
            Assert.Equal(user.Id, publicUser.Id);
            Assert.Equal(user.Username, publicUser.Username);
            Assert.Equal(user.Karma, publicUser.Karma);
            Assert.Null(publicUser.Email);
            Assert.Null(publicUser.Password);
            Assert.Null(publicUser.EncryptionKey);
        }
    }
}
