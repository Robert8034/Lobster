using System;
using System.Collections.Generic;
using System.Text;
using Application.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using Lobster.Server.Services.Authentication;
using Lobster.Server.Services.EncryptionServices;
using Moq;
using Xunit;

namespace Lobster.Server.Services.Test.Authentication
{
    public class AuthenticationServiceTests
    {
        private readonly Mock<Repository<User>> _userRepositoryMock;
        private readonly IEncryptionService _encryptionService;

        public AuthenticationServiceTests()
        {
            _userRepositoryMock = new Mock<Repository<User>>();
            _encryptionService = new EncryptionService();
        }

        [Fact]
        public void LoginUserTest()
        {
            //ARRANGE
            User user1 = new User
            {
                Username = "Test",
                Password = _encryptionService.Encrypt("Wachtwoord", "XYZ"),
                EncryptionKey = "XYZ",
                Email = "Test@Test"
            };

            User user2 = new User
            {
                Username = "Test2",
                Password = _encryptionService.Encrypt("Wachtwoord2", "XYZ"),
                EncryptionKey = "XYZ",
                Email = "Test@Test"
            };

            _userRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(user1);
            });

            var authenticationService = new AuthenticationService(_userRepositoryMock.Object, _encryptionService);

            //ACT
            var result = authenticationService.LoginUser(new LoginModel
            {
                Username = "Test",
                Password = "Wachtwoord"
            });

            //ASSERT
            Assert.Equal(user1.Username, result.Username);
            Assert.Equal(user1.Password, result.Password);
            Assert.Equal(user1.EncryptionKey, result.EncryptionKey);
            Assert.Equal(user1.Email, result.Email);
        }

        [Fact]
        public void RegisterUserTest()
        {
            //ARRANGE
            _userRepositoryMock.SetupRepositoryMock(options => { });

            var authenticationService = new AuthenticationService(_userRepositoryMock.Object, _encryptionService);

            //ACT
            var result = authenticationService.RegisterUser(new RegisterModel
            {
                Email = "Test@Test",
                Password = "Wachtwoord",
                Username = "Test"
            });

            //ASSERT
            Assert.NotNull(result);
            Assert.Equal("Test@Test", result.Email);
            Assert.Equal("Test", result.Username);
        }
    }
}
