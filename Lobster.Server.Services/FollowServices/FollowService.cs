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

        public bool FollowUser(int userId, int followerId)
        {
            if (_followRepository.TableNoTracking.Any(e => e.UserId == userId && e.FollowerId == followerId))
                return false;

            _followRepository.Insert(new Follow
            {
                UserId = userId,
                FollowerId = followerId
            });
            return true;
        }

        public List<Follow> GetFollows(int userId)
        {
            return _followRepository.Table.Where(a => a.UserId == userId).ToList();
        }

        public bool UnfollowUser(int userId, int followerId)
        {
            if (!_followRepository.TableNoTracking.Any(e => e.UserId == userId && e.FollowerId == followerId))
                return false;

            Follow follow =
                _followRepository.TableNoTracking.SingleOrDefault(e =>
                    e.UserId == userId && e.FollowerId == followerId);

            _followRepository.Delete(follow);
            return true;
        }
    }
}
