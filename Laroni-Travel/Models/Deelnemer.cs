using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Laroni_Travel.Models
{
    public partial class Deelnemer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int DeelnemerId { get; set; }

        [Required]
        public bool Admin { get; set; }       

        [Required]
        public string Email { get; set; }

        [Required]
        public string Familienaam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Geboortedatum { get; set; }

        [Required]
        public string Gemeente { get; set; }

        [Required]
        public string Geslacht { get; set; }

        [Required]
        public bool HoofdMonitor { get; set; }

        [Required]
        public string Huisnummer { get; set; }       

        [Required]
        public bool Monitor { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Straatnaam { get; set; }

        [Required]
        public string Voornaam { get; set; }

        [Required]
        public bool Ziekenfonds { get; set; }

        [Required]
        public string Wachtwoord { get; set; }

        [NotMapped]
        public int Leeftijd { get { return DateTime.Now.Year - Geboortedatum.Year; } }

        [NotMapped]
        public string GeboortedatumInfo { get { return Geboortedatum.ToString("dd-MM-yyyy"); } }

        //Navigatieproperty
        public ICollection<DeelnemerGroepsreis> DeelnemerGroepsreizen { get; set; }
        public ICollection<DeelnemerOpleiding> DeelnemerOpleidingen { get; set; }
        public ICollection<Medisch> Medische { get; set; }
    }
}