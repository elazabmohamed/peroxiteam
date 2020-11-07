using peroxiteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.DataProcessor.ActProcessor;
using System.Web.SessionState;
using peroxiteam.SessionAttirbute;
using Act = peroxiteam.Models.Act;

namespace peroxiteam.Controllers
{
    //[CheckSession]
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddAct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAct(Act model)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateAct(model.Id, model.Type, model.Name, model.Category, model.Description, model.Comments);
                return RedirectToAction("Index", "Company");
            }

            return View();
        }


        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }
    }
}
