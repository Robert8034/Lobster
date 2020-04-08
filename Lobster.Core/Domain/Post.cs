using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Post : BaseEntity
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public DateTime PostDate { get; set; }
        public List<Like> Likes { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
