using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace News.Data.EF
{
    class DbContextFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public AppDbContext Create(Type repositoryType)
        {
            var services = _httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, AppDbContext>>();
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<AppDbContext>();

            return dbContexts[repositoryType];
        }
    }
}
