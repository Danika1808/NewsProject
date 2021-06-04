using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.News
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Rating { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        public string Content { get; set; }
        public List<Photo> Photos { get; set; } = new List<Photo>();
        public List<Comment> Comments { get; set; } = new List<Comment>();
        public int Views { get; set; }

        public Post()
        {
        }
    }
}
