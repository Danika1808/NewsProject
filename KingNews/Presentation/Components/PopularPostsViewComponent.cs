using Domain.Models.News;
using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Components
{
    public class PopularPostsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;

        public PopularPostsViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var popularPosts = await _context.Posts.Include(x => x.Category).ToListAsync();

            var group = popularPosts
                .AsParallel()
                .GroupBy(x => x.Category.First().Name)
                .ToDictionary(x => x.Key, x => x.OrderByDescending(y => y.Rating).ToList());

            var dict = new Dictionary<string, List<Post>>();


            return View();
        }
    }
}
