using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Domain.Models.News;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Presentation.Models;
using System.Linq.Expressions;

namespace Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var actualPosts = _context.Posts
                .OrderByDescending(x => x.Rating)
                .Take(5)
                .Include(x => x.Categories)
                .Include(x => x.Photos)
                .ToList();

            var popularPosts = _context.Posts
                .OrderByDescending(x => x.Rating)
                .Include(x => x.Categories)
                .Include(x => x.Photos)
                .Take(6).ToList();

            var latestPosts = _context.Posts
                .OrderByDescending(x => x.Date)
                .Include(x => x.Categories)
                .Include(x => x.Photos)
                .Include(x => x.Comments)
                .Take(5).ToList();

            var worldPosts = _context.Posts
                .Where(x => x.Categories.Any(y => y.Name.Equals("World")))
                .OrderByDescending(x => x.Date)
                .Include(x => x.Categories)
                .Include(x => x.Photos)
                .Include(x => x.Comments)
                .Take(5).ToList();

            var indexViewModel = new IndexViewModel
            {
                ActualPosts = actualPosts,
                PopularPosts = popularPosts,
                LatestPosts = latestPosts,
                WorldPosts = worldPosts
            };
            return View(indexViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
