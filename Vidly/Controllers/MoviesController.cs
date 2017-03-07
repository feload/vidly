using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{  
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            var movies = new List<Movie>()
            {
                new Movie() { Name = "Shark!" },
                new Movie() { Name = "Tank!" },
                new Movie() { Name = "Barracuda!" },
            };

            return View(movies);
        }

        [Route("movies/released/{year:regex(\\d{4})}/(month:regex(\\d{2}):range(1, 12))")]
        public ActionResult ByReleaseDate(int year, int month)
        {
            return Content(String.Format("{0} {1}", year, month));
        }
    }
}