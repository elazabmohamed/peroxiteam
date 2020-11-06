using peroxiteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.Processor.StudentProcessor;

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
                int recordsCreated = CreateStudent(model.Id, model.Name, model.SurName, model.StudentNo,
                                     model.UniversityMail, model.University, model.Department, model.Grade,
                                     model.Password, model.StudentState);
                return RedirectToAction("Index");
            }

            return View();
        }


        public ActionResult SignIn()
        {
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(LogIn model)
        {
            if (ModelState.IsValid)
            {

                if (CheckLog(model.UniversityMail, model.Password))
                {

                    Session["Member_Email"] = model.UniversityMail;
                    return RedirectToAction("Index", "Member");
                 //  return RedirectToAction("Index", "Home");

                }
                else
                {
                    ViewBag.Message = String.Format("Sorry, you are not registered.");
                    return View();
                }
            }
            return View();
        }


    }
}