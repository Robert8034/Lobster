using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Data;
using Lobster.Core.Domain;
using Lobster.Core.Models;
using Lobster.Server.Services.PostingServices;
using Moq;
using Xunit;
using Follow = Lobster.Core.Models.Follows.Follow;

namespace Lobster.Server.Services.Test.Posting
{
    public class PostingServiceTests
    {
        private readonly Mock<Repository<Post>> _postingRepositoryMock;
        private readonly Mock<Repository<Like>> _likingRepositoryMock;
        private readonly Mock<Repository<Reaction>> _reactingRepositoryMock;

        public PostingServiceTests()
        {
            _postingRepositoryMock = new Mock<Repository<Post>>();
            _likingRepositoryMock = new Mock<Repository<Like>>();
            _reactingRepositoryMock = new Mock<Repository<Reaction>>();
        }

        [Fact]
        public void CreatePostTest()
        {
            //ARRANGE
            _postingRepositoryMock.SetupRepositoryMock(options => { });

            var postingService = new PostingService(_postingRepositoryMock.Object, null, null);

            //ACT
            postingService.CreatePost(new PostModel
            {
                Content = "Test",
                PostDate = DateTime.Now,
                UserId = 1
            });

            var post = postingService.GetPost(1);

            //ASSERT
            Assert.Equal("Test", post.Content);
            Assert.Equal(1, post.UserId);
        }

        [Fact]
        public void GetPostTest()
        {
            //ARRANGE
            _postingRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(new Post
                {
                    Id = 1,
                    Content = "Test",
                    UserId = 1
                });
            });

            var postingService = new PostingService(_postingRepositoryMock.Object, null, null);

            //ACT
            var post = postingService.GetPost(1);

            //ASSERT
            Assert.Equal(1, post.Id);
            Assert.Equal(1, post.UserId);
            Assert.Equal("Test", post.Content);
        }

        [Fact]
        public void GetTimelineTest()
        {
            //ARRANGE
            _postingRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(new Post
                {
                    Id = 1,
                    UserId = 1
                });
                options.Insert(new Post
                {
                    Id = 2,
                    UserId = 1
                });
                options.Insert(new Post
                {
                    Id = 3,
                    UserId = 1
                });
                options.Insert(new Post
                {
                    Id = 4,
                    UserId = 2
                });
            });

            List<Follow> follows = new List<Follow>
            {
                new Follow
                {
                    Id = 1,
                    UserId = 1,
                    FollowerId = 1
                }
            };

            var postingService = new PostingService(_postingRepositoryMock.Object, null, null);

            //ACT
            List<Post> posts = postingService.GetTimeline(follows);

            //ASSERT
            Assert.Equal(3, posts.Count);
            Assert.Equal(1, posts[0].UserId);
            Assert.Equal(1, posts[1].UserId);
            Assert.Equal(1, posts[2].UserId);
            Assert.Equal(3, posts[0].Id);
            Assert.Equal(2, posts[1].Id);
            Assert.Equal(1, posts[2].Id);
        }

        [Fact]
        public void LikePostTest()
        {
            //ARRANGE
            _likingRepositoryMock.SetupRepositoryMock(options => {});

            var postingService = new PostingService(null, _likingRepositoryMock.Object, null);

            //ACT
            postingService.LikePost(1, 1);

            var result = postingService.GetLike(1, 1);

            //ASSERT
            Assert.Equal(1, result.Id);
            Assert.Equal(1, result.UserId);
            Assert.Equal(1, result.PostId);

        }

        [Fact]
        public void RemoveLikeTest()
        {
            //ARRANGE
            Like like1 = new Like{Id = 1, PostId = 1, UserId = 1};
            Like like2 = new Like { Id = 2, PostId = 2, UserId = 1 };

            _likingRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(like1);
                options.Insert(like2);
            });

            var postingService = new PostingService(null, _likingRepositoryMock.Object, null);

            //ACT
            postingService.RemoveLike(like1);

            var result = postingService.GetLike(1, 1);

            //ASSERT
            Assert.Null(result);
        }

        [Fact]
        public void CheckIfLikedTest()
        {
            //ARRANGE
            Like like = new Like{Id = 1, PostId = 1, UserId = 1};

            _likingRepositoryMock.SetupRepositoryMock(options => { options.Insert(like); });

            var postingService = new PostingService(null, _likingRepositoryMock.Object, null);

            //ACT
            var result = postingService.CheckIfLiked(1, 1);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public void GetLikeTest()
        {
            //ARRANGE
            Like like1 = new Like{Id = 1, PostId = 1, UserId = 1};
            Like like2 = new Like { Id = 2, PostId = 2, UserId = 1 };

            _likingRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(like1);
                options.Insert(like2);
            });

            var postingService = new PostingService(null, _likingRepositoryMock.Object, null);

            //ACT
            var like = postingService.GetLike(1, 1);

            //ASSERT
            Assert.Equal(1, like.Id);
            Assert.Equal(1, like.UserId);
            Assert.Equal(1, like.PostId);
        }

        [Fact]
        public void ReactOnPostTest()
        {
            //ARRANGE
            _reactingRepositoryMock.SetupRepositoryMock(options => { });

            var postingService = new PostingService(null, null, _reactingRepositoryMock.Object);

            Core.Models.Reactions.Reaction reactionModel = new Core.Models.Reactions.Reaction
            {
                Content = "Test",
                Id = 1,
                PostDate = DateTime.Now,
                PostId = 1,
                UserId = 1
            };

            //ACT
            postingService.ReactOnPost(reactionModel);

            var reaction = postingService.GetReaction(1);

            //ASSERT
            Assert.NotNull(reaction);
            Assert.Equal(1, reaction.Id);
            Assert.Equal(1, reaction.PostId);
            Assert.Equal(1, reaction.UserId);
            Assert.Equal("Test", reaction.Content);
        }

        [Fact]
        public void GetReactionTest()
        {
            //ARRANGE
            Reaction reaction = new Reaction{Id = 1, PostId = 1, UserId = 1, Content = "Test"};

            _reactingRepositoryMock.SetupRepositoryMock(options => { options.Insert(reaction); });

            var postingService = new PostingService(null, null, _reactingRepositoryMock.Object);

            //ACT
            var actualReaction = postingService.GetReaction(1);

            //ASSERT
            Assert.Equal(reaction.Id, actualReaction.Id);
            Assert.Equal(reaction.PostId, actualReaction.PostId);
            Assert.Equal(reaction.UserId, actualReaction.UserId);
            Assert.Equal(reaction.Content, actualReaction.Content);

        }

    }
}
