using Lobster.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class GroupMember : BaseEntity
    {
        public int GroupId { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }
    }
}
