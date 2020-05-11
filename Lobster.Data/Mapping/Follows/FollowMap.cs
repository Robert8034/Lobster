using System;
using System.Collections.Generic;
using System.Text;
using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lobster.Data.Mapping.Follows
{
    public class FollowMap : EntityMappingConfiguration<Follow>
    {
        public override void Configure(EntityTypeBuilder<Follow> builder)
        {
            builder.HasKey(e => new { e.Id, e.UserId});
            builder.HasOne(e => e.User).WithMany(e => e.Follows).HasForeignKey(e => e.UserId);
        }
    }
}
