using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.FollowServices
{
    public interface IFollowService
    {
        public Task<List<Follow>> GetFollows(int userId);
    }
}
