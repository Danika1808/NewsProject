using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using Infrastructure.Context;
using Infrastructure.Repository;
using Domain.Models.News;

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

            services.AddScoped<Dictionary<Type, AppDbContext>>();
            services.AddSingleton<DbContextFactory>();
            services.AddSingleton<IRepository<Post>, Repository<Post>>();
            return services;
        }
    }
}
