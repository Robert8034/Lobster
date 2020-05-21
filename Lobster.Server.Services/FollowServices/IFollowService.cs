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
        bool FollowUser(int userId, int followerId);
        bool UnfollowUser(int userId, int followerId);
    }
}
