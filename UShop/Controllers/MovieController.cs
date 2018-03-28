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
            var model = context.Movies.Include(g => g.Genre).ToList();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = context.Movies.Include(g => g.Genre).SingleOrDefault(m => m.Id == id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        public ActionResult Create()
        {
            //populate genre
            var genre = context.Genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                Genres = genre,
                Movie = new Movie() //pass empty movie
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Movie xyz)
        {
            try
            {
                context.Movies.Add(xyz);
                context.SaveChanges();
            }
            catch(DbEntityValidationException dbe)
            {
                Response.Write(dbe);
            }
            return RedirectToAction("Index");
        }
    }
}