using Domain.Models.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Models
{
    public class IndexViewModel
    {
        public List<Post> ActualPosts { get; set; }
        public List<Post> PopularPosts { get; set; }
        public List<Post> LatestPosts { get; set; }
        public List<Post> WorldPosts { get; set; }

    }
}
