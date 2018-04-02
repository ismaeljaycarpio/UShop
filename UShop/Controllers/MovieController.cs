using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UShop.Models;
using UShop.Entities;
using System.Data.Entity;
using UShop.ViewModels;
using System.Data.Entity.Validation;

namespace UShop.Controllers
{
    public class MovieController : Controller
    {
        private ApplicationDbContext context;

        public MovieController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            context.Dispose();
        }
        // GET: Movie
        public ActionResult Index()
        {
            //var model = context.Movies.Include(g => g.Genre).ToList();
            //return View(model);
            if (User.IsInRole(RoleName.CanManageMovies))
                return View();
            return View("ReadOnlyList");
        }

        public ActionResult Details(int id)
        {
            var model = context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles= RoleName.CanManageMovies)]
        public ActionResult Create()
        {
            var listOfGenres = context.Genres.ToList();
            var model = new MovieViewModel
            {
                Genres = listOfGenres
            };

            return View("MovieForm", model);
        }

        public ActionResult Edit(int id)
        {
            var movie = context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            var movieViewModel = new MovieViewModel(movie)
            {
                Genres = context.Genres.ToList()
            };

            ViewBag.Title = "Edit";
            return View("MovieForm", movieViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Movie movie)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new MovieViewModel(movie)
                {
                    Genres = context.Genres.ToList()
                };
            }

            if (movie.Id == 0) //insert
            {
                movie.DateAdded = DateTime.Now;
                context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = context.Movies.SingleOrDefault(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
            }
                           
            context.SaveChanges();
            return RedirectToAction("Index", "Movie");
        }
    }
}