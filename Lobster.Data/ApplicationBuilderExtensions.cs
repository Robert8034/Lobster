using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lobster.Data
{
    public static class ApplicationBuilderExtensions
    {
        /// <summary>
        /// Ensure that the database exists with all its tables and default data.
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public static void EnsureMigrated(this IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetService<DbContext>();

                var relationalDatabaseCreator =
                    (RelationalDatabaseCreator)dbContext.Database.GetService<IDatabaseCreator>();

                var databaseExists = relationalDatabaseCreator.Exists() && relationalDatabaseCreator.HasTables();

                dbContext.Database.Migrate();

                if (!databaseExists)
                {
                    //Create Data
                }

            }
        }
    }
}
