using Lobster.Core.Data;
using Lobster.Core.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Lobster.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IRepository<User>, Repository<User>>();


            return serviceCollection;
        }
    }
}
