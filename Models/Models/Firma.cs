﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Firma
    {
        [Key]
        public int FirmaPK { get; set; } 
        public string Naziv { get; set; }
    }
}
