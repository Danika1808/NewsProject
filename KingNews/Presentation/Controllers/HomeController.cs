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
            var categories = _context.Categories.ToList();

            var dict = new Dictionary<string, Category>();

            foreach (var item in categories)
            {
                dict.Add(item.Name, item);
            }

            var posts = new List<Post>
            {
                new Post
                {
                    Category = {dict["Tech"], dict["Sports"] },
                    Name = "Penis",
                    Content = "Член в принципе хороший, симметричная форма, но стоит побрить а так 8/5",
                    Date = DateTime.UtcNow,
                    Photos =
                    {
                        new Photo
                        {
                            Patch = "assets/1733635482_0_0_2879_1919_1440x900_80_0_1_b724c64b6996bb8dc40f5c3a69464491.jpg.webp"
                        }
                    },
                    Rating = 5.0M
                },
                new Post
                {
                    Category = {dict["Tech"], dict["Sports"] },
                    Name = "Penis",
                    Content = "Член в принципе хороший, симметричная форма, но стоит побрить а так 8/5",
                    Date = DateTime.UtcNow,
                    Photos =
                    {
                        new Photo
                        {
                            Patch = "assets/1733635482_0_0_2879_1919_1440x900_80_0_1_b724c64b6996bb8dc40f5c3a69464491.jpg.webp"
                        }
                    },
                    Rating = 5.0M
                },
                new Post
                {
                    Category = {dict["Tech"], dict["Sports"] },
                    Name = "Penis",
                    Content = "Член в принципе хороший, симметричная форма, но стоит побрить а так 8/5",
                    Date = DateTime.UtcNow,
                    Photos =
                    {
                        new Photo
                        {
                            Patch = "assets/1733635482_0_0_2879_1919_1440x900_80_0_1_b724c64b6996bb8dc40f5c3a69464491.jpg.webp"
                        }
                    },
                    Rating = 5.0M
                },
            };
            _context.Posts.AddRange(posts);
            _context.SaveChanges();
            return View();
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
