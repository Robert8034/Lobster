using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Likes
{
    [AutoMap(typeof(Domain.Like))]
    public class Like
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
