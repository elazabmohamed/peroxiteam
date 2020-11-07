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
using System.Text.RegularExpressions;
using Student = peroxiteam.Models.Student;

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



        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public ActionResult AddAct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAct(Act model, HttpPostedFileBase ModelImage)
        {

            model.Id = int.Parse(RandomString(8));

            string CreateFolderforModel = Regex.Replace(model.Name.Trim() + "-" + model.Id.ToString(), @"\s+", "_");

            while (Directory.Exists(model.Name.Trim() + "-" + model.Id.ToString()))
            {
                model.Id = int.Parse(RandomString(8));

                CreateFolderforModel = Regex.Replace(model.Name.Trim() + "-" + model.Id.ToString(), @"\s+", "_");
            }


            Directory.CreateDirectory(Server.MapPath("~/Content/Acts/" + CreateFolderforModel + "/Image/"));

            if (ModelImage != null && ModelImage.ContentLength > 0)
                try
                {

                    string imagePath = Path.Combine(Server.MapPath("~/Content/Acts/" + CreateFolderforModel + "/Image/"),
                       Regex.Replace(Path.GetFileName(ModelImage.FileName), @"\s+", "_"));

                    ModelImage.SaveAs(imagePath);
                    //Saving info to database model

                    model.ImagePath = "/Content/Acts/" + CreateFolderforModel + "/Image/" + Regex.Replace(Path.GetFileName(ModelImage.FileName), @"\s+", "_");



                    //model.ImagePath = "/Content/Models/" + CreateFolderforModel + "/Image/" + Regex.Replace(Path.GetFileName(ModelImage.FileName), @"\s+", "_");
                    ViewBag.Message = "Act's image uploaded successfully";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Lütfen bir dosyayı seçin";
            }



            if (ModelState.IsValid)
            {
                int recordsCreated = CreateAct(model.Id, model.Type, model.Name, model.Category, model.Description, model.Comments, model.ImagePath);
                return RedirectToAction("Index", "Company");
            }

            return View();
        }


        public ActionResult ViewCandidates()
        {
            var data = DataLibrary.DataProcessor.StudentProcessor.LoadModels();
            List<Student> models = new List<Student>();

            foreach (var row in data)
            {
                models.Add(new Student
                {
                    Id = row.Id,
                    Name = row.Name,
                    SurName = row.SurName,
                    StudentNo = row.StudentNo,
                    Tag = row.Tag,
                    Grade= row.Grade,
                    UniversityMail = row.UniversityMail,
                    University = row.University,
                    Department = row.Department,
                    CvPath = row.CvPath,
                    ImagePath = row.ImagePath
                });
            }
            return View(models);
        }




        public ActionResult ViewCandidate(int id)
        {
            var data = DataLibrary.DataProcessor.StudentProcessor.LoadSpecificModel(id);
            List<Student> models = new List<Student>();

            foreach (var row in data)
            {
                models.Add(new Student
                {
                    Id = row.Id,
                    Name = row.Name,
                    SurName= row.SurName,
                    StudentNo = row.StudentNo,
                    University = row.University,
                    UniversityMail = row.UniversityMail,
                    Department = row.Department,
                    Grade = row.Grade,
                    StudentState = row.StudentState,
                    Tag = row.Tag,
                    CvPath = row.CvPath,
                    ImagePath = row.ImagePath
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
