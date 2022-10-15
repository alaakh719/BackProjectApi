using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Model.DTO
{
    public class CompanyViewModel
    {
        [Required]

        [Display(Name = "Company's name")]
        public string NameAr { get; set; }
        [Display(Name = "Country")]
        public int Country { get; set; }
        [Required]
        [Display(Name = "logo")]
        public IFormFile file { get; set; }
        [Display(Name = "logo")]
        public string logoImg { get; set; }
    }
}
