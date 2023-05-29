using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Medisch
    {
        [Key]
        public int MedischId { get; set; }
        public int DeelnemerId { get; set; }
        [Required]
        public string Omschrijving { get; set; }
        [Required]
        public string Medicatie { get; set; }
        [Required]
        public string Behandeling { get; set; }

        //Navigatieproperty
        public Deelnemer Deelnemer { get; set; }
    }
}
