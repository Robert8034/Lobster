using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Lobster.Core.Domain;
using Lobster.Data;
using Lobster.Server.Services.FollowServices;
using Moq;
using Xunit;

namespace Lobster.Server.Services.Test.Following
{
    public class FollowServiceTests
    {

        private readonly Mock<Repository<Follow>> _followRepositoryMock;

        public FollowServiceTests()
        {
            _followRepositoryMock = new Mock<Repository<Follow>>();
        }

        [Fact]
        public void FollowUserTest()
        {
            //ARRANGE
            _followRepositoryMock.SetupRepositoryMock(options => { });

            var followService = new FollowService(_followRepositoryMock.Object);

            //ACT
            followService.FollowUser(1, 1);

            var result = followService.GetFollow(1, 1);

            //ASSERT
            Assert.Equal(1, result.UserId);
            Assert.Equal(1, result.FollowerId);
            Assert.Equal(0, result.Id);

        }

        [Fact]
        public void UnfollowUserTest()
        {
            //ARRANGE
            Follow follow1 = new Follow{FollowerId = 1, Id = 1, UserId = 1};
            Follow follow2 = new Follow { FollowerId = 2, Id = 2, UserId = 2 };

            _followRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(follow1);
                options.Insert(follow2);
            });

            var followService = new FollowService(_followRepositoryMock.Object);

            //ACT
            followService.UnfollowUser(follow1);

            var result = followService.GetFollow(1,1);

            //ASSERT
            Assert.Null(result);

        }

        [Fact]
        public void GetFollowsTest()
        {
            //ARRANGE
            List<Follow> follows = new List<Follow>
            {
                new Follow
                {
                    Id = 1,
                    UserId = 1,
                    FollowerId = 1
                },
                new Follow
                {
                    Id = 2,
                    UserId = 1,
                    FollowerId = 2
                },
                new Follow
                {
                    Id = 3,
                    UserId = 2,
                    FollowerId = 2
                },
            };

            _followRepositoryMock.SetupRepositoryMock(options => { options.Insert(follows); });

            var followService = new FollowService(_followRepositoryMock.Object);

            //ACT
            List<Follow> actualFollows = followService.GetFollows(1);

            //ASSERT
            for (int i = 0; i < actualFollows.Count; i++)
            {
                 Assert.Equal(follows[i].UserId, actualFollows[i].UserId);
                 Assert.Equal(follows[i].FollowerId, actualFollows[i].FollowerId);
            }
        }

        [Fact]
        public void CheckIfFollowedTest()
        {
            //ARRANGE
            Follow follow1 = new Follow{Id = 1, FollowerId = 1, UserId = 1};

            _followRepositoryMock.SetupRepositoryMock(options => { options.Insert(follow1); });

            var followService = new FollowService(_followRepositoryMock.Object);

            //ACT
            var result = followService.CheckIfFollowed(1, 1);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public void GetFollowTest()
        {
            //ARRANGE
            Follow follow1 = new Follow{Id = 1, FollowerId = 1, UserId = 1};
            Follow follow2 = new Follow { Id = 2, FollowerId = 2, UserId = 1 };

            _followRepositoryMock.SetupRepositoryMock(options =>
            {
                options.Insert(follow1);
                options.Insert(follow2);
            });

            var followService = new FollowService(_followRepositoryMock.Object);

            //ACT
            var result = followService.GetFollow(1, 1);

            //ASSERT
            Assert.Equal(1, result.Id);
            Assert.Equal(1, result.UserId);
            Assert.Equal(1, result.FollowerId);

        }
    }
}
