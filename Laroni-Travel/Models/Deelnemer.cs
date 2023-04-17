﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class Deelnemer
    {
        [Key]
        public int DeelnemerId { get; set; }
        [Required]
        public string Voornaam { get; set; }
        [Required]
        public string Familiennaam { get; set; }
        [Required]
        public string Straatnaam { get; set; }
        [Required]
        public string Huisnummer { get; set; }
        [Required]
        public string Postcode { get; set; }
        [Required]
        public string Gemeente { get; set; }
        [Required]
        public DateOnly Geboortedatum { get; set; }
        [Required]
        public string Geslacht { get; set; }
        [Required]
        public bool Ziekenfonds { get; set; }
        [Required]
        public bool Monitor { get; set; }
        [Required]
        public bool HoofdMonitor { get; set; }
        [Required]
        public bool Admin { get; set; }

        //Navigatieproperty
        public virtual Bestemming Bestemming { get; set; }
        public virtual ICollection<Opleiding> opleidingen { get; set; }
        public virtual ICollection<DeelnemerOpleiding> deelnemerOpleiding { get; set; }
    }
}