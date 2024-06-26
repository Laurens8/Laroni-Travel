﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class DeelnemerOpleiding
    {
        [Key]
        public int DeelnemerOpleidingId { get; set; }
        [Required]
        public int DeelnemerId { get; set; }
        [Required]
        public int OpleidingId { get; set; }

        //Navigatieproperty
        public Deelnemer Deelnemer { get; set; }
        public Opleiding Opleiding { get; set; }
    }
}
