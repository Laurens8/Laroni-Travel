using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class LeeftijdsCategorie
    {
        [Key]
        public int LeeftijdsCategorieId { get; set; }
        [Required]
        public string Naam { get; set; }
    }
}
