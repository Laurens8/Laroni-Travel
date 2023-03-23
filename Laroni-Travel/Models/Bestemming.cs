using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class Bestemming
    {
        [Key]
        public int BestemmingId { get; set; }
        [Required]
        public string Naam { get; set; }
        [Required]       
        public string Straatnaam { get; set; }
        [Required]      
        public string Huisnummer { get; set; }
        [Required]     
        public string Postcode { get; set; }
        [Required]   
        public string Gemeente { get; set; }
        [Required]
        public string Land { get; set; }

        //Navigatieproperty
        public virtual ICollection<OpleidingBestemming> opleidingBestemming { get; set; }
        public virtual ICollection<Deelnemer> deelnemers { get; set; }
        public virtual ICollection<Opleiding> opleidingen { get; set; }
    }
}
