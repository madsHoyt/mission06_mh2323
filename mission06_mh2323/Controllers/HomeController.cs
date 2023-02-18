using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ViewBag.Categories = _movieContext.Categories.ToList();

            return View();
        }
        //Post for Movies page
        [HttpPost]
        public IActionResult Movies(Movie mv)
        {
            if (ModelState.IsValid)
            { 
                //Add and Save input to db
                _movieContext.Add(mv);
                _movieContext.SaveChanges();

                return View("confirmation", mv);
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View();
            }
        }
        public IActionResult Confirmation()
        {
            return View();
        }
        public IActionResult MyPodcasts()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //Movie List
        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = _movieContext.responses
                .Include(x => x.Category)
                .OrderBy(x=> x.Title).ToList();
            return View(movies);
        }
        //Edit View
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = _movieContext.Categories.ToList();
            var movieEntry = _movieContext.responses.Single(x => x.MovieId == movieid);
            return View("Movies", movieEntry);
        }
        [HttpPost]
        public IActionResult Edit(Movie mc)
        {
            if (ModelState.IsValid)
            {
                //Add and Save input to db
                _movieContext.Update(mc);
                _movieContext.SaveChanges();

                return RedirectToAction("MovieList");
            }
            else
            {
                ViewBag.Categories = _movieContext.Categories.ToList();
                return View("Movies");
            }
        }
        //Delete View
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
           var movieEntry = _movieContext.responses.Single(x => x.MovieId == movieid);

            return View(movieEntry);
        }
        [HttpPost]
        public IActionResult Delete (Movie md)
        {
            _movieContext.responses.Remove(md);
            _movieContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
