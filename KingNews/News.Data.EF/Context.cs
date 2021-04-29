using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace News.Data.EF
{
    public class Context : IdentityDbContext
    {
        public Context(DbContextOptions<Context> options)
        : base(options)
        { }

        public DbSet<News> News { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Image> Images { get; set; }
    }
}