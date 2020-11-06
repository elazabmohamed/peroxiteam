using peroxiteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using
using DataLibrary.Models;

namespace peroxiteam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult SignUp()
        {
            ViewBag.Message = "Üye ol";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(StudentModel model)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}