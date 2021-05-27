using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Infrastructure.Context;

namespace Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseNpgsql(connectionString);
                },
                ServiceLifetime.Transient
            );
            return services;
        }
    }
}
