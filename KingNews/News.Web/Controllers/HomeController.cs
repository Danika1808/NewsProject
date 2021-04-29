using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using News.Web.App;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using News.Web.Models;

namespace News.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<News> _repository;

        public HomeController(IRepository<News> repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var category = new Category();
            category.Name = "Test";
            var news = new News("Kek", DateTime.Now, 17.0m, category, "lol", null);
            _repository.Create(news);
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
