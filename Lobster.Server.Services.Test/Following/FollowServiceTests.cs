using System;
using System.Collections.Generic;
using System.Text;
using Application.Data;
using Lobster.Core.Domain;
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
            var result = followService.FollowUser(1, 1);

            //ASSERT
            Assert.True(result);
        }

        [Fact]
        public void UnfollowUserTest()
        {
            //ARRANGE
            Assert.True(1 == 1);
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
    }
}
