using Lobster.Core.Data;
using Lobster.Core.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public Permissions Permissions { get; set; }
    }
}
