using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace peroxiteam.Models
{
    public class Student
    {
        public int Id { get; set; }
        [DisplayName("Ad")]
        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        public string SurName { get; set; }

        [DisplayName("Öğrenci No")]
        [Required(ErrorMessage = "Lütfen öğrenci numaranızı giriniz.")]
        //[DataType(DataType.Currency)]
        //[DataType(DataType.Custom)]
        [StringLength(20, MinimumLength = 9, ErrorMessage = "En az 10 karakter girmeniz lazım.")]
        public string StudentNo { get; set; }

        [DisplayName("E-posta")]
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Lütfen E-posta adresinizi giriniz.")]
        public string UniversityMail { get; set; } 

        [DisplayName("Üniversite")]
        [Required(ErrorMessage = "Lütfen okuduğunuz üniversiteyi giriniz.")]
        public string University { get; set; }

        [DisplayName("Bölüm")]
        [Required(ErrorMessage = "Lütfen okuduğunuz bölümü giriniz.")]
        public string Department { get; set; }

        [DisplayName("Sınıf")]
        [Required(ErrorMessage = "Lütfen kaçınıcı sınıfta olduğunuzu girniz.")]
        public string Grade { get; set; }



        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Lütfen şifrenizi girniz.")]
        public string Password { get; set; }


        [DisplayName("Daha önce staj tecrübeniz oldu mu?")]
        [Required(ErrorMessage = "Lütfen bu alanı doldurunuz girniz.")]
        public string StudentState { get; set; }



    }
}


