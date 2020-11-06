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
    [CheckSession]
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
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments
                });
            }
            return View(models);
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Member/Create
        public ActionResult Create()
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
                    Category = row.Category,
                    Description = row.Description,
                    Comments = row.Comments
                });
            }
            return View(models);
        }




    }
}
