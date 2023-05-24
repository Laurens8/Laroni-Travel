using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class Opleiding
    {
        [Key]
        public int OpleidingId { get; set; }
        [Required]
        public string Beschrijving { get; set; }
        [Required]
        public DateTime Datum { get; set; }       

        [Required]
        public int AantalDeelnemers { get { return DeelnemerOpleidingen.Count(); } }

        [NotMapped]
        public string DatumInfo { get { return Datum.ToString("dd-MM-yyyy"); } }

        //Navigatieproperty
        public OpleidingBestemming OpleidingBestemmingen { get; set; }
        public ICollection<DeelnemerOpleiding> DeelnemerOpleidingen { get; set; }
    }
}
