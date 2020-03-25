using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class GroupPost : BaseEntity
    {
        public int GroupId { get; set; }
        public string Content { get; set; }
        public List<Like> Likes { get; set; }
        public List<Reaction> Reactions { get; set; }
    }
}
