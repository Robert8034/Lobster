using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lobster.Client.Services.Liking;
using Lobster.Client.Services.Reacting;
using Lobster.Core.Data;
using Lobster.Core.Models.Posts;
using Lobster.Core.Models.Reactions;
using Moq;
using Moq.Protected;
using Xunit;

namespace Lobster.Client.Services.Test.Services.Reacting
{
    public class ReactingServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;

        public ReactingServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }


        [Fact]
        public async Task ReactOnPostTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new Post
            {
                Id = 1,
                UserId = 1,
                Reactions = new List<Reaction>
                {
                    new Reaction
                    {
                        Content = "Test",
                        PostId = 1,
                        UserId = 1
                    }
                }
            }));

            var reactingService = new ReactionService(_httpClient);

            //ACT
            Post post = await reactingService.ReactOnPost(1, 1, "Test");

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Put
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post/react")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal(1, post.Id);
            Assert.Equal(1, post.UserId);
            Assert.Equal(1, post.Reactions[0].PostId);
            Assert.Equal(1, post.Reactions[0].UserId);
            Assert.Equal("Test", post.Reactions[0].Content);
        }
    }
}
