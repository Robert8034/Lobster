using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class GroupMessage : BaseEntity
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public string Content { get; set; }
    }
}
