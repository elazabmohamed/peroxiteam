using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace peroxiteam.Models
{
    public class Company
    {
        public int Id { get; set; }
        [DisplayName("Kurum Adı")]
        [Required(ErrorMessage = "Lütfen kurum adınızı giriniz.")]
        public string CompanyName { get; set; }

        [DisplayName("E-posta")]
        [Required(ErrorMessage = "Kuruma ait E-posta adresinizi giriniz.")]
        [DataType(DataType.EmailAddress)]
        public string CompanyMail { get; set; }

        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifrenizi giriniz.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "En az 10 karakter girmeniz lazım.")]
        public string Password { get; set; }
        public string Tag { get; set; }

    }
}