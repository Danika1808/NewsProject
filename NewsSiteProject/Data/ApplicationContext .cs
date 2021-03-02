using Microsoft.EntityFrameworkCore;
using System;
using Entities;

namespace Data
{
    public class ApplicationContext : DbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
           : base(options) {}
        
        public DbSet<News> News { get; private set; } 
    }
}
