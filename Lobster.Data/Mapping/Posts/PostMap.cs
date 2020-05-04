using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data.Mapping.Posts
{
    public class PostMap : EntityMappingConfiguration<Post>
    {
        public override void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
