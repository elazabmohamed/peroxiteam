using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace peroxiteam.Models
{
    public class LogIn
    {
        [DisplayName("E-posta")]
        [Required(ErrorMessage = "E-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string UniversityMail { get; set; }
        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "En az 10 karakter girmeniz lazım.")]
        public string Password { get; set; }
    }
}