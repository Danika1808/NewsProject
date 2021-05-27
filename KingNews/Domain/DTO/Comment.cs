using Domain.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Content { get; set; }

        public User User { get; set; }

        public Guid? PostId  { get; set; }
        public Post Post { get; set; }
    }
}
