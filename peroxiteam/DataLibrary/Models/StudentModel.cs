using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
   public class StudentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string StudentNo { get; set; }
        public string UniversityMail { get; set; }
        public string University { get; set; }
        public string Department { get; set; }
        public string Grade { get; set; }
        public string Password { get; set; }
        public string StudentState { get; set; }
    }
}
