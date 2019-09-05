using System;
using Microsoft.Extensions.DependencyInjection;

namespace jabbR.Services
{
    public static class JabbRDependencyInjectionExtensions
    {
        public static IServiceCollection AddJabbRServices(this IServiceCollection serviceCollection)
        {
            if (serviceCollection == null)
            {
                throw new ArgumentNullException(nameof(serviceCollection));
            }

            serviceCollection.AddSingleton<IJabbrRepository>();
            serviceCollection.AddSingleton<ContentProviderProcessor>();
            serviceCollection.AddSingleton<IChatService>();
            serviceCollection.AddSingleton<IRecentMessageCache>();
            serviceCollection.AddSingleton<ApplicationSettings>();
            
            serviceCollection.AddMemoryCache();

            return serviceCollection;
        }
    }
}
