using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UShop.Models;

namespace UShop.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        //[OutputCache(Duration=50)] //action filter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //throw new Exception();

            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}