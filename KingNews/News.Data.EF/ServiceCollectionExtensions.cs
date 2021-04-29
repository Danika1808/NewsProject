using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

namespace News.Data.EF
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContextFactory<Context>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                },
                ServiceLifetime.Transient
            );

            services.AddScoped<Dictionary<Type, Context>>();
            services.AddSingleton<INewsRepository, NewsRepository>();
            return services;
        }
    }
}
