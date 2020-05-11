using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Follow : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int FollowerId { get; set; }
        public User Follower { get; set; }

    }
}
