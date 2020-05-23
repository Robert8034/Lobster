using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lobster.Client.Services.FollowServices;
using Lobster.Client.Services.Liking;
using Lobster.Core.Data;
using Lobster.Core.Models.Posts;
using Moq;
using Moq.Protected;
using Xunit;

namespace Lobster.Client.Services.Test.Services.Liking
{
    public class LikingServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;

        public LikingServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }

        [Fact]
        public async Task LikePostTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new Post
            {
                Id = 1,
                UserId = 1
            }));

            var likingService = new LikingService(_httpClient);

            //ACT
            Post post = await likingService.LikePost(1, 1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post/1/like/1")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

           Assert.Equal(1, post.Id);
           Assert.Equal(1, post.UserId);

        }

        [Fact]
        public async Task RemoveLikeTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new Post
            {
                Id = 1,
                UserId = 1
            }));

            var likingService = new LikingService(_httpClient);

            //ACT
            Post post = await likingService.RemoveLike(1, 1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post/1/like/1/remove")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal(1, post.Id);
            Assert.Equal(1, post.UserId);

        }
    }
}
