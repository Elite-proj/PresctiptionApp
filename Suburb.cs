﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace E_prescription
{
    public partial class Suburb
    {
        public int SuburbId { get; set; }
        public int? CityId { get; set; }
        public string SuburbName { get; set; }

        public virtual City City { get; set; }
    }
}