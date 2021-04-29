using System;
using System.Collections.Generic;

namespace News
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public virtual List<News> Entities { get; private set; }

        protected Category()
        { 
        }
    }
}