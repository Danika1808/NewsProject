using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace News.Data.EF
{
    class NewsRepository : INewsRepository
    {

        private readonly DbContextFactory _dbContextFactory;

        public NewsRepository(DbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public void Create(News item)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));
            dbContext.News.Add(item);
            dbContext.SaveChanges();
        }

        public News FindById(int id)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));
            return dbContext.News.Find(id);
        }

        public IEnumerable<News> Get()
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));

            return dbContext.News;
        }

        public IEnumerable<News> Get(Func<News, bool> predicate)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));
            return dbContext.News.Where(predicate).ToList();
        }

        public IEnumerable<News> GetWithInclude(params Expression<Func<News, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<News> GetWithInclude(Func<News, bool> predicate,
            params Expression<Func<News, object>>[] includeProperties)
        {
            var query = Include(includeProperties);
            return query.Where(predicate).ToList();
        }

        public void Remove(News item)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));
            dbContext.Remove(item);
            dbContext.SaveChanges();
        }

        public void Update(News item)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));
            dbContext.Update(item);
            dbContext.SaveChanges();
        }

        private IQueryable<News> Include(params Expression<Func<News, object>>[] includeProperties)
        {
            var dbContext = _dbContextFactory.Create(typeof(NewsRepository));

            IQueryable<News> query = dbContext.News.AsNoTracking();
            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
