using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.News
{
    public class Post
    {
        public Guid Id { get; protected set; }
        public string Name { get; protected set; }
        public DateTime Date { get; protected set; }
        public decimal Rating { get; protected set; }
        public Category Category { get; protected set; }
        public string Content { get; protected set; }
        public Photo? Image { get; protected set; }

        protected Post()
        {
        }
    }
}
