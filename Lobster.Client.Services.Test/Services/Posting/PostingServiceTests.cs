using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Lobster.Client.Services.Posting;
using Lobster.Core.Data;
using Lobster.Core.Models;
using Lobster.Core.Models.Posts;
using Moq;
using Moq.Protected;
using Xunit;

namespace Lobster.Client.Services.Test.Services.Posting
{
    public class PostingServiceTests
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;
        private readonly HttpClient _httpClient;

        public PostingServiceTests()
        {
            _httpMessageHandlerMock = new Mock<HttpMessageHandler>(MockBehavior.Strict);

            _httpClient = new HttpClient(_httpMessageHandlerMock.Object)
            {
                BaseAddress = new Uri("https://localhost:5001/")
            };
        }

        [Fact]
        public async Task GenerateTimelineTest()
        {
            //ARRANGE
            List<Post> posts = new List<Post>
            {
                new Post
                {
                    Id = 1,
                    UserId = 1
                },
                new Post
                {
                    Id = 1,
                    UserId = 1
                },
                new Post
                {
                    Id = 1,
                    UserId = 1
                }
            };

            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new TimelineModel
            {
                Timeline = posts
                
            }));

            var postingService = new PostingService(_httpClient);

            //ACT
            List<Post> actualPosts = await postingService.GenerateTimeline(1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post/generatetimeline/1")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            for (int i = 0; i < posts.Count; i++)
            {
                Assert.Equal(posts[i].Id, actualPosts[i].Id);
                Assert.Equal(posts[i].UserId, actualPosts[i].UserId);
            }
        }

        [Fact]
        public async Task CreateNewPostTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK));

            var postingService = new PostingService(_httpClient);

            //ACT
            await postingService.CreateNewPost(new PostModel
            {
                Content = "Test",
                UserId = 1
            });

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Post
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal(1, 1);
        }


        [Fact]
        public async Task GetPostTest()
        {
            //ARRANGE
            _httpMessageHandlerMock.SetupHttpMessageHandlerMock(HttpStatusCode.OK, new RestResponse(HttpStatusCode.OK, new Post
            {
                UserId = 1,
                Id = 1
            }));

            var postingService = new PostingService(_httpClient);

            //ACT
            var post = await postingService.GetPost(1);

            //ASSERT
            _httpMessageHandlerMock.Protected().Verify("SendAsync", Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get
                    && req.RequestUri == new Uri("https://localhost:5001/api/Post/1")
                ),
                ItExpr.IsAny<CancellationToken>()
            );

            Assert.Equal(1, post.Id);
            Assert.Equal(1, post.UserId);
        }
    }
}
