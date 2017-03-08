using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{  
    public class MoviesController : Controller
    {
        private readonly Context _context;
        public MoviesController()
        {
            _context = new Context();
        }

        protected override void Dispose(bool isDisposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        public ActionResult Details(int Id)
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(c => c.Id == Id);
            if (movie == null)
                return HttpNotFound();

            return View(movie);
        }
    }
}