using Domain.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public decimal Rating { get; set; }
        public List<Category> Category { get; set; }
        public string Content { get; set; }
        public List<Photo> Photos { get; set; }
        public List<Comment> Comments { get; set; }
        public int Views { get; set; }

        public Post()
        {
        }
    }
}
