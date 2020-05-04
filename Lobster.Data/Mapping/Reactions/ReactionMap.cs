using System;
using System.Collections.Generic;
using System.Text;
using Lobster.Core.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lobster.Data.Mapping.Reactions
{
    public class ReactionMap : EntityMappingConfiguration<Reaction>
    {
        public override void Configure(EntityTypeBuilder<Reaction> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }
}
