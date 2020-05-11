using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Follows
{
    [AutoMap(typeof(Domain.Follow))]
    public class Follow
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int FollowerId { get; set; }

    }
}
