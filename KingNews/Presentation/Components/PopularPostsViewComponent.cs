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
            var dict = new Dictionary<string, List<Post>>
            {
                {
                    "All News",
                    await _context.Posts

                .OrderByDescending(x => x.Rating)
                .Take(6)
                .Include(x => x.Category)
                .Include(x => x.Photos)
                .ToListAsync()
                }
            }
            .Concat(_context.Posts
                .Include(x => x.Category)
                .Include(x => x.Photos)
                .ToList()
                .GroupBy(x => x.Category.First().Name)
                .ToDictionary(x => x.Key, x => x.OrderByDescending(y => y.Rating).Take(6).ToList())).ToDictionary(x => x.Key, x => x.Value); ;


            return View(dict);
        }
    }
}
