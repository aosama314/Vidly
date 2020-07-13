using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {

        //private VidlyContext Context;

        private ApplicationDbContext Context;

        public MoviesController()
        {
            Context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            Context.Dispose();
        }

        // Movies
        public ActionResult Index()
        {
            var movies = Context.Movies.Include(m => m.Genre).ToList();
            if (User.IsInRole("CanManageMovies"))
            {
                return View("List", movies);
            }
            return View("ReadOnlyList", movies);
        }

        public ActionResult Details(int id)
        {
            var movie = Context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.ID == id);
            return View(movie);
        }

        public ActionResult New()
        {
            var genres = Context.Genres.ToList();
            var viewModel = new NewMovieViewModel()
            {
                Genres = genres
            };
            return View(viewModel);
        }

        public ActionResult Edit(int id)
        {
            var movie = Context.Movies.SingleOrDefault(m => m.ID == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel(movie)
            {
                Genres = Context.Genres.ToList()
            };
            return View("New", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel(movie)
                {
                    Genres = Context.Genres.ToList()
                };
                return View("New", viewModel);
            }
            if (movie.ID == 0)
            {
                movie.DataAdded = DateTime.Now;
                Context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = Context.Movies.Single(m => m.ID == movie.ID);

                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.DataAdded = DateTime.Now;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
            Context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

    }
}