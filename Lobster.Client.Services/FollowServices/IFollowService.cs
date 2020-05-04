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
    }
}
