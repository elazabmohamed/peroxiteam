using peroxiteam.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using DataLibrary.Models;
using static DataLibrary.DataProcessor.StudentProcessor;
using static DataLibrary.DataProcessor.ActProcessor;
using System.Web.SessionState;
using peroxiteam.SessionAttirbute;
using Act = peroxiteam.Models.Act;
using Student = peroxiteam.Models.Student;
using Company = peroxiteam.Models.Company;

namespace peroxiteam.Controllers
{
    [CheckSession]
    public class MemberController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Staj - İş ilanları";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadModels("Staj");
            List<Act> models = new List<Act>();

            foreach (var row in data)
            {
                models.Add(new Act
                {
                    Id = row.Id,
                    NameOfActor = row.NameOfActor,
                    Name = row.Name,
                    Type = row.Type,
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments, 
                    ImagePath = row.ImagePath
                });
            }
            return View(models);
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


        public ActionResult ViewComments()
        {
            ViewBag.Message = "Staj - İş ilanları";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadModels("Yorum");
            List<Act> models = new List<Act>();

            foreach (var row in data)
            {
                models.Add(new Act
                {
                    Id = row.Id,
                    Name = row.Name,
                    Type = row.Type,
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments,
                    ImagePath = row.ImagePath,
                    NameOfActor = row.NameOfActor
                });
            }
            return View(models);
        }


        public ActionResult AddAct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAct(Act model)
        {
            model.Type = "Yorum";

            if (model.ImagePath == null)
            {
                model.ImagePath = "/Content/bgImage/yorum.jpg";
            }
            if (ModelState.IsValid)
            {
                int recordsCreated = CreateAct(model.Id, model.Type, model.Name, model.Category, model.Description, model.Comments, model.ImagePath, model.NameOfActor);
                return RedirectToAction("Index", "Company");
            }

            return View();
        }



        public ActionResult ViewActs()
        {
            ViewBag.Message = "Staj - İş ilanları";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadModels("Staj");
            List<Act> models = new List<Act>();

            foreach (var row in data)
            {
                models.Add(new Act
                {
                    Id = row.Id,
                    Name = row.Name,
                    Type = row.Type,
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments,
                    ImagePath = row.ImagePath,
                    NameOfActor = row.NameOfActor
                });
            }
            return View(models);
        }



        public ActionResult ViewAct(int id)
        {
            ViewBag.Message = "Staj - İş ilanı";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadSpecificModel(id);
            List<Act> models = new List<Act>();

            foreach (var row in data)
            {
                models.Add(new Act
                {
                    Id = row.Id,
                    Name = row.Name,
                    Type = row.Type,
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments, 
                    ImagePath = row.ImagePath,
                    NameOfActor = row.NameOfActor
                });
            }
            return View(models);
        }




        public ActionResult Apply(int id)
        {
            return View();
        }



        public ActionResult RozetContest()
        {
            var data = DataLibrary.DataProcessor.CompanyProcessor.LoadModels();
            List<Company> models = new List<Company>();

            foreach (var row in data)
            {
                models.Add(new Company
                {
                    Id = row.Id,
                    CompanyName = row.CompanyName,
                    CompanyMail = row.CompanyMail,
                    Tag = row.Tag,
                });
            }
            return View(models);
        }

        





        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }


    }
}
