using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BackProjectApi.Model
{
    public class Company
    {
        public int id { get; set; }
        [Required]
        public string NameAr { get; set; }

        [Required]
        public int Cityid { get; set; }
        public City city { get; set; }

        [Required]
        public string logo { get; set; }
    }
}
