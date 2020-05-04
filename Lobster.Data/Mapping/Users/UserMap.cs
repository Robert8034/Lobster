using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data.Mapping.Users
{
    public class UserMap : EntityMappingConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
