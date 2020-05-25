using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.FollowServices
{
    public interface IFollowService
    {
        public List<Follow> GetFollows(int userId);
        void FollowUser(int userId, int followerId);
        void UnfollowUser(Follow follow);
        bool CheckIfFollowed(int userId, int followerId);
        Follow GetFollow(int userId, int followerId);
    }
}
