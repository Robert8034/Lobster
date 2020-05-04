using AutoMapper;
using Lobster.Core.Domain.Roles;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Core.Models.Roles
{
    [AutoMap(typeof(Domain.Role))]
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Permissions Permissions { get; set; }
    }
}
