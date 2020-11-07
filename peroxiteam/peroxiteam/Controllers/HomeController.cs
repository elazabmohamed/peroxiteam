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
using System.Text.RegularExpressions;

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


        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Üye ol";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Student model, HttpPostedFileBase ModelImage, HttpPostedFileBase ModelFile)
        {


            model.Id = int.Parse(RandomString(8));

            string CreateFolderforModel = Regex.Replace(model.Name.Trim() + "-" +model.SurName.Trim()+ "-"+ model.Id.ToString(), @"\s+", "_");

            while (Directory.Exists(model.Name.Trim() + "-" + model.Id.ToString()))
            {
                model.Id = int.Parse(RandomString(8));

                CreateFolderforModel = Regex.Replace(model.Name.Trim() + "-" + model.SurName.Trim() + "-" + model.Id.ToString(), @"\s+", "_");
            }
            Directory.CreateDirectory(Server.MapPath("~/Content/Students/" + CreateFolderforModel + "/Image/"));


            if (ModelImage != null && ModelImage.ContentLength > 0)
                try
                {

                    string imagePath = Path.Combine(Server.MapPath("~/Content/Students/" + CreateFolderforModel + "/Image/"),
                       Regex.Replace(Path.GetFileName(ModelImage.FileName), @"\s+", "_"));

                    ModelImage.SaveAs(imagePath);

                    model.ImagePath = "/Content/Students/" + CreateFolderforModel + "/Image/" + Regex.Replace(Path.GetFileName(ModelImage.FileName), @"\s+", "_");


                    ViewBag.Message = "Model's image uploaded successfully";

                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Bir doysa seçmeniz lazım.";
            }


            Directory.CreateDirectory(Server.MapPath("~/Content/Students/" + CreateFolderforModel + "/CV/"));
            if (ModelFile != null && ModelFile.ContentLength > 0)
                try
                {
                    string modelPath = Path.Combine(Server.MapPath("~/Content/Students/" + CreateFolderforModel + "/CV/"),
                                              Regex.Replace(Path.GetFileName(ModelFile.FileName), @"\s+", "_"));

                    ModelFile.SaveAs(modelPath);

                    model.CvPath = "/Content/Student/" + CreateFolderforModel + "/CV/" + Regex.Replace(Path.GetFileName(ModelFile.FileName), @"\s+", "_");

                    ViewBag.Message = "Model uploaded successfully";
                }
                catch (Exception ex)
                {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else
            {
                ViewBag.Message = "Bir doysa seçmeniz lazım.";
            }

            ///         tag=rozet, ilerde staj tecrübelerine göre sınıflandırılarak her öğrenciye bir rozet atanacak. 
            ///         Şimdilik rastgele atanıyor
            ///         
            Random r = new Random();
            int rInt = r.Next(0, 3); 

            model.Tag = "~/Content/rozetler/" + rInt.ToString().Trim() + ".png";
                            

            if (ModelState.IsValid)
            {
                int recordsCreated = CreateStudent(model.Id, model.Name, model.SurName, model.StudentNo,
                                     model.UniversityMail, model.University, model.Department, model.Grade,
                                     model.Password, model.StudentState, model.Tag, model.CvPath, model.ImagePath);
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