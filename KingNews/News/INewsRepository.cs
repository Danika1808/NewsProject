using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News
{
    public interface INewsRepository
    {
        void Create(News item);
        News FindById(int id);
        IEnumerable<News> Get();
        IEnumerable<News> Get(Func<News, bool> predicate);
        void Remove(News item);
        void Update(News item);
    }
}
