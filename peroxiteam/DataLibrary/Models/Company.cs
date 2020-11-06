using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
   public class Company
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyMail { get; set; }
        public string Password { get; set; }
        public string Tag { get; set; }
    }
}
