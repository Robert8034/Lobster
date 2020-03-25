using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Reaction : BaseEntity
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
