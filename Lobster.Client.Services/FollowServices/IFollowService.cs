using Lobster.Core.Models.Follows;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Client.Services.FollowServices
{
    public interface IFollowService
    {
        public Task<List<Follow>> GetFollows(int userId);
        public Task<List<Follow>> FollowUser(int userId, int followerId);
        public Task<List<Follow>> UnfollowUser(int userId, int followerId);


    }
}
