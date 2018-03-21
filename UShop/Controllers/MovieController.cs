using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UShop.Models;
using UShop.Entities;
using System.Data.Entity;

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
    }
}