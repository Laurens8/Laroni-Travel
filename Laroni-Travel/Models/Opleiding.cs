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
        public int BestemmingId { get; set; }
        [Required]
        public int DeelnemerId { get; set; }
        [Required]
        public int RolId { get; set; }

        //Navigatieproperty
        public ICollection<DeelnemerOpleiding> deelnemerOpleiding { get; set; }
        public Rol Rol { get; set; }
        public Bestemming Bestemming { get; set; }
    }
}
