using peroxiteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.DataProcessor.StudentProcessor;
using static DataLibrary.DataProcessor.CompanyProcessor;
using Student = peroxiteam.Models.Student;
using Company = peroxiteam.Models.Company;

namespace peroxiteam.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Intro()
        {

            return View();
        }
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
        public ActionResult SignUp(Student model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateStudent(model.Id, model.Name, model.SurName, model.StudentNo,
                                     model.UniversityMail, model.University, model.Department, model.Grade,
                                     model.Password, model.StudentState, model.Tag);
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

                    Session["Student_Email"] = model.UniversityMail;
                    return RedirectToAction("Index", "Member");
                 //  return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = String.Format("Sistemde kayıtlı değilsiniz.");
                    return View();
                }
            }
            return View();
        }


        public ActionResult SignUpCompany()
        {
            ViewBag.Message = "Üye ol";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUpCompany(Company model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateCompany(model.Id, model.CompanyName,model.CompanyMail, model.Password, model.Tag);
                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult SignInCompany()
        {
            ViewBag.Message = "";
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignInCompany(LogIn model)
        {
            if (ModelState.IsValid)
            {

                if (CheckLogCompany(model.UniversityMail, model.Password))
                {

                    Session["Company_Email"] = model.UniversityMail;
                    return RedirectToAction("Index", "Company");
                    //  return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Message = String.Format("Sistemde kayıtlı değilsiniz.");
                    return View();
                }
            }
            return View();
        }

    }
}