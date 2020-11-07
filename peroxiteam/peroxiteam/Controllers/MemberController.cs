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

namespace peroxiteam.Controllers
{
    //[CheckSession]
    public class MemberController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Staj - İş ilanları";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadModels();
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
            

            return View();
        }
        public ActionResult ViewActs()
        {
            ViewBag.Message = "Staj - İş ilanları";
            var data = DataLibrary.DataProcessor.ActProcessor.LoadModels();
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
                    ImagePath = row.ImagePath
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
                    ImagePath = row.ImagePath
                });
            }
            return View(models);
        }




        public ActionResult Apply(int id)
        {


            return View();
        }


        public ActionResult AddComment()
        {


            return View();
        }






        public ActionResult LogOff()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");

        }


    }
}
