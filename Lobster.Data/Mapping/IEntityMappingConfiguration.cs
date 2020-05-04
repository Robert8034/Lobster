using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data.Mapping
{
    public interface IEntityMappingConfiguration
    {
        void ApplyConfiguration(ModelBuilder modelBuilder);

    }
}
