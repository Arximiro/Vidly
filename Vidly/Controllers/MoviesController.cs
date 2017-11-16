using System;
using System.Data.Entity;
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
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        [Authorize(Roles = RoleName.Manager)]  // This attribute prevents a guest user from going to /movies/new on their own for example and being able to create a new movie.
        public ActionResult New() // NEW
        {
            var genres = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genres
            };

            return View("MovieForm", viewModel);
        }




        [HttpPost, ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.Manager)]
        public ActionResult Save(Movie movie) // SAVE
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList()
                };

                return View("MovieForm", viewModel);
            }

            var movies = _context.Movies.ToList();

            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Now;
                _context.Movies.Add(movie);
            }
            
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Movies");
        }



        [Authorize(Roles = RoleName.Manager)]
        public ActionResult Edit(int id) // EDIT
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }




        public ActionResult Index() // INDEX
        {
            if (User.IsInRole(RoleName.Manager))
                return View();

            return View("ReadOnlyIndex");
        }




        public ActionResult Details(int id) // DETAILS
        {
            var movie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return HttpNotFound();

            if (User.IsInRole(RoleName.Manager))
                return View(movie);

            return View("ReadOnlyDetails", movie);
        }
    }
}