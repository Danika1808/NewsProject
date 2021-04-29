using System;
using System.Collections.Generic;

namespace News
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<News> Entities { get; set; }

        public Category()
        { 
        }
    }
}