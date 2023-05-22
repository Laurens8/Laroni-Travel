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
        public int BestemmingId { get; set; }

        [Required]
        public int ThemaId { get; set; }

        [Required]
        public int LeeftijdsCategorieId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Einddatum { get; set; }
                    
        [Required]
        [Column(TypeName = "money")]
        public float Prijs { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Startdatum { get; set; }            

        //Navigatieproperty
        public Bestemming Bestemming { get; set; }
        public LeeftijdsCategorie LeeftijdsCategorieen { get; set; }
        public Thema Thema { get; set; }

        [NotMapped]
        public float Drinkgeld { get {
                return Prijs * 0.05f;
            } }
    }
}