using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UShop.Models;

namespace UShop.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext context;

        public CustomerController()
        {
            context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            context.Dispose();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var model = context.Customers;
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var model = context.Customers.SingleOrDefault(c => c.Id == id);
            if (model == null)
                return HttpNotFound();

            return View(model);
        }
    }
}