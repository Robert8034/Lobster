using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Like : BaseEntity
    {
        public int UserId { get; set; }
        public int PostId { get; set; }
    }
}
