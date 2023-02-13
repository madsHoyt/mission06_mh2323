using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mission06_mh2323.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace mission06_mh2323.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MovieContext _movieContext { get; set; }
        public HomeController(ILogger<HomeController> logger, MovieContext movie)
        {
            _logger = logger;
            _movieContext = movie;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        //Get for Movies page
        [HttpGet]
        public IActionResult Movies()
        {
            return View();
        }
        //Post for Movies page
        [HttpPost]
        public IActionResult Movies(Movie mv)
        {
            //Add and Save input to db
            _movieContext.Add(mv);
            _movieContext.SaveChanges();

            return View(mv);
        }

        public IActionResult MyPodcasts()
        {
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
