using Lobster.Core.Data;
using Lobster.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lobster.Server.Services.FollowServices
{
    public class FollowService : IFollowService
    {
        private readonly IRepository<Follow> _followRepository;
        public FollowService(IRepository<Follow> followRepository)
        {
            _followRepository = followRepository;
        }
        public async Task<List<Follow>> GetFollows(int userId)
        {
            return _followRepository.Table.Where(a => a.UserId == userId).ToList();
        }

    }
}
