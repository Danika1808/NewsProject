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
            var popularPosts = _context.Posts
                .Include(x => x.Category)
                .ToList()
                .GroupBy(x => x.Category.First().Name)
                .ToDictionary(x => x.Key, x => x.OrderByDescending(y => y.Rating).Take(6).ToList());

            popularPosts("All", await _context.Posts
                .Include(x => x.Category)
                .OrderByDescending(x => x.Rating)
                .Take(6)
                .ToListAsync());

            return View(popularPosts);
        }
    }
}
