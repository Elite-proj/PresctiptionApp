﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace E_prescription.Models
{
    public class ProvinceModel
    {
        [Key]
        public int ProvinceID { get; set; }

        public string ProvinceName { get; set; }

        public ICollection<CityModel> cities { get; set; }
    }
}
