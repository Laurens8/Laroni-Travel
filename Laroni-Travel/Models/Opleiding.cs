﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Opleiding
    {
        [Key]
        public int OpleidingId { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public DateTime Datum { get; set; }
        [Required]
        public int MaxAantalDeelnemers { get; set; }

        [NotMapped]
        public string? AantalDeelnemers
        {
            get
            {
                if (DeelnemerOpleidingen == null)
                {
                    return "0 / " + MaxAantalDeelnemers.ToString();
                }
                else
                {
                    return DeelnemerOpleidingen.Count().ToString() + " / " + MaxAantalDeelnemers.ToString();
                }
            }
        }

        [NotMapped]
        public string DatumInfo { get { return Datum.ToString("dd-MM-yyyy"); } }       

        //Navigatieproperty
        //public ICollection<OpleidingBestemming> OpleidingBestemmingen { get; set; }
        public OpleidingBestemming OpleidingBestemmingen { get; set; }
        public ICollection<DeelnemerOpleiding> DeelnemerOpleidingen { get; set; }
    }
}
