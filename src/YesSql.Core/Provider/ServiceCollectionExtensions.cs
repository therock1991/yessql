﻿using System;
using YesSql.Core.Services;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDbProvider(
            this IServiceCollection services,
            Action<Configuration> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            var config = new Configuration();
            setupAction.Invoke(config);
            services.AddSingleton<IStore>(new Store(config));

            return services;
        }
    }
}