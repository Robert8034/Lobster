using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Group : BaseEntity
    {
        public string Groupname { get; set; }
        public List<Post> Messages { get; set; }
    }
}
