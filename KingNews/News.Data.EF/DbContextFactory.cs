using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace News.Data.EF
{
    class DbContextFactory : IDesignTimeDbContextFactory<Context>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DbContextFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public DbContextFactory()
        { 
        }

        public Context Create(Type repositoryType)
        {
            var services = _httpContextAccessor.HttpContext.RequestServices;

            var dbContexts = services.GetService<Dictionary<Type, Context>>();
            if (!dbContexts.ContainsKey(repositoryType))
                dbContexts[repositoryType] = services.GetService<Context>();

            return dbContexts[repositoryType];
        }

        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();
            optionsBuilder.UseNpgsql("Server=dtsitis.postgres.database.azure.com;UserName=postgres@dtsitis;Database=postgres;Port=5432;Password=12345Qwert;SSLMode=Prefer");

            return new Context(optionsBuilder.Options);
        }
    }
}
