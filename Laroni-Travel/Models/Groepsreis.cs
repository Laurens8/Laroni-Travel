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
        //Navigatieproperty
        public Bestemming Bestemming { get; set; }

        [Required]
        public int BestemmingId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Einddatum { get; set; }

        [Key]
        public int GroepsreisId { get; set; }

        public LeeftijdsCategorie LeeftijdsCategorieen { get; set; }

        [Required]
        public int LeeftijdsCategorieId { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public float Prijs { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Startdatum { get; set; }

        public Thema Thema { get; set; }

        [Required]
        public int ThemaId { get; set; }
    }
}