using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lobster.Client.Services.FollowServices;
using Lobster.Core.Data;
using Lobster.Core.Models;
using Lobster.Core.Models.Follows;
using Lobster.Core.Models.Users;
using Moq;
using Moq.Protected;
using Xunit;

namespace Lobster.Client.Services.Test.Services.Following
{
    public class FollowServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;

        public FollowServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }

        [Fact]
        public async Task GetFollowsTest()
        {
            //ARRANGE
            List<Follow> follows = new List<Follow>
            {
                new Follow()
                {
                    FollowerId = 1,
                    Id = 1,
                    UserId = 1
                },
                new Follow()
                {
                    FollowerId = 2,
                    Id = 2,
                    UserId = 2
                },
                new Follow()
                {
                    FollowerId = 3,
                    Id = 3,
                    UserId = 3
                }
            };

            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, follows));

            var followService = new FollowService(_httpClient);

            //ACT
            List<Follow> actualFollows = await followService.GetFollows(1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post
                    && req.RequestUri == new Uri("https://localhost:5001/api/Follow/getFollows")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            for (int i = 0; i < actualFollows.Count; i++)
            {
                Assert.Equal(follows[i].Id, actualFollows[i].Id);
                Assert.Equal(follows[i].UserId, actualFollows[i].UserId);
                Assert.Equal(follows[i].FollowerId, actualFollows[i].FollowerId);
            }
        }

        [Fact]
        public async Task FollowUserTest()
        {
            //ARRANGE
            List<Follow> follows = new List<Follow>
            {
                new Follow()
                {
                    FollowerId = 1,
                    Id = 1,
                    UserId = 1
                },
                new Follow()
                {
                    FollowerId = 2,
                    Id = 2,
                    UserId = 2
                }
            };

            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, follows));

            var followService = new FollowService(_httpClient);

            //ACT
            List<Follow> actualFollows = await followService.FollowUser(1, 1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put
                    && req.RequestUri == new Uri("https://localhost:5001/api/follow/1/follows/1/add")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            for (int i = 0; i < actualFollows.Count; i++)
            {
                Assert.Equal(follows[i].Id, actualFollows[i].Id);
                Assert.Equal(follows[i].UserId, actualFollows[i].UserId);
                Assert.Equal(follows[i].FollowerId, actualFollows[i].FollowerId);
            }
        }

        [Fact]
        public async Task UnfollowUserTest()
        {
            //ARRANGE
            List<Follow> follows = new List<Follow>
            {
                new Follow()
                {
                    FollowerId = 1,
                    Id = 1,
                    UserId = 1
                },
                new Follow()
                {
                    FollowerId = 2,
                    Id = 2,
                    UserId = 2
                }
            };

            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, follows));

            var followService = new FollowService(_httpClient);

            //ACT
            List<Follow> actualFollows = await followService.UnfollowUser(1, 1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put
                    && req.RequestUri == new Uri("https://localhost:5001/api/follow/1/follows/1/remove")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            for (int i = 0; i < actualFollows.Count; i++)
            {
                Assert.Equal(follows[i].Id, actualFollows[i].Id);
                Assert.Equal(follows[i].UserId, actualFollows[i].UserId);
                Assert.Equal(follows[i].FollowerId, actualFollows[i].FollowerId);
            }
        }
    }
}
