using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Domain.Roles
{
    [Flags]
    public enum Permissions
    {
        None = 0,
        User = 1 << 1,
        Admin = 1 << 2,
        All = ~None
    }
}
