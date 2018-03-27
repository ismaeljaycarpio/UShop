using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UShop.Models;
using System.Data.Entity;
using UShop.ViewModels;
using UShop.Entities;

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
            var model = context.Customers.Include(c => c.MembershipType).ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var membershipTypes = context.MembershipTypes.ToList(); //get membership types
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes,

            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(Customer customer) //model binding
        {
            if(customer.Id == 0)
                context.Customers.Add(customer);
            else
            {
                var customerInDb = context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerInDb); // not good approach

                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.BirthDate = customer.BirthDate;

            }
            context.SaveChanges(); //wrap in transaction

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var model = context.Customers.Include(c => c.MembershipType)
                .SingleOrDefault(c => c.Id == id);
            
            if (model == null)
                return HttpNotFound();

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var customer = context.Customers.SingleOrDefault(m => m.Id == id);
            if (customer == null)
                return HttpNotFound();

            var model = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = context.MembershipTypes.ToList()
            };

            return View("Create", model);
            //return RedirectToAction("Index");
        }
    }
}