using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data.Mapping.Likes
{
    public class LikeMap : EntityMappingConfiguration<Like>
    {
        public override void Configure(EntityTypeBuilder<Like> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
