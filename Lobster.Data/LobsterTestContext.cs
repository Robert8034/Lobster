using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Lobster.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Lobster.Data
{
    /// <summary>
    /// A DbContext for unit tests.
    /// </summary>
    public class LobsterTestContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var configurations = Assembly.GetExecutingAssembly().GetTypes().Where(t =>
                (t.BaseType?.IsGenericType ?? false) && t.BaseType?.GetGenericTypeDefinition() == typeof(EntityMappingConfiguration<>));

            foreach (Type configurationType in configurations)
            {
                var configuration = (IEntityMappingConfiguration)Activator.CreateInstance(configurationType);
                configuration.ApplyConfiguration(modelBuilder);
            }

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("LobsterTests");
        }
    }
}
