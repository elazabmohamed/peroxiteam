﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace peroxiteam.Models
{
    public class Act
    {
        public int Id { get; set; }
        [DisplayName("İş/Staj ilanı - İş/Staj ile ilgili Mentor yorumu")]
        [Required(ErrorMessage = "İşlem türünü giriniz.")]
        public string Type { get; set; }
        [DisplayName("Başlık")]
        [Required(ErrorMessage = "İşleminiz için başlık türünü giriniz.")]
        public string Name { get; set; }

        [DisplayName("Kategori")]
        [Required(ErrorMessage = "İşleminizin ait olduğu kategoriyi giriniz.")]
        public string Category { get; set; }

        [DisplayName("Açıklama")]
        [Required(ErrorMessage = "Açıklama giriniz.")]
        public string Description { get; set; }

        public string Comments { get; set; }

    }
}