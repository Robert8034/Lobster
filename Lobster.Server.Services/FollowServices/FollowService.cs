using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.FollowServices
{
    public class FollowService : IFollowService
    {
        public List<Follow> GetFollows(int userId)
        {
            return new List<Follow>();
        }

    }
}
