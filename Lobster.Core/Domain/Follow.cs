using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Follow : BaseEntity
    {
        public int UserId { get; set; }

        public int FollowId { get; set; }

    }
}
