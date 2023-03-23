using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class Groepsreis
    {
        [Key]
        public int GroepsreisId { get; set; }
        [Required]
        public string BestemmingId { get; set; }
        [Required]
        public string ThemaId { get; set; }
        [Required]
        public string LeeftijdsCategorieId { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public float Prijs { get; set; }

        public Bestemming bestemming { get; set; }
        public Thema thema { get; set; }
        public LeeftijdsCategorie leeftijdsCategorie { get; set; }
    }
}
