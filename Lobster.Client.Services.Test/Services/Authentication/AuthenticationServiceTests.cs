using Lobster.Client.Services.Authentication;
using Lobster.Core.Data;
using Lobster.Core.Models.Users;
using Moq;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Lobster.Core.Models;
using Xunit;
using Moq.Protected;

namespace Lobster.Client.Services.Test.Services.Authentication
{
    public class AuthenticationServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;

        public AuthenticationServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }

        [Fact]
        public async Task RegisterTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new User
            {
                Id = 1,
                Username = "test"
            }));

            var authenticationService = new AuthenticationService(_httpClient);

            //ACT
            User user = await authenticationService.Register(new RegisterModel
            {
                Email = "test@test.nl",
                Password = "testword",
                Username = "test"
            });

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
            ItExpr.Is<HttpRequestMessage>(req =>
            req.Method == HttpMethod.Post
            && req.RequestUri == new Uri("https://localhost:5001/api/User/register")
                ),
            ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal("test", user.Username);
        }

        [Fact]
        public async Task LoginTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new User
            {
                Id = 1,
                Username = "test",
                Password = "testword"
            }));

            var authenticationService = new AuthenticationService(_httpClient);

            //ACT
            User user = await authenticationService.Login(new LoginModel
            {
                Password = "testword",
                Username = "test"
            });

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post
                    && req.RequestUri == new Uri("https://localhost:5001/api/User/login")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal("test", user.Username);
            Assert.Equal("testword", user.Password);
        }

    }
}
