using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class OpleidingBestemming
    {
        [Key]
        public int OpleidingBestemmingId { get; set; }
        [Required]
        public int OpleidingId { get; set; }
        [Required]
        public int BestemmingId { get; set; }

        //Navigatieproperty
        public Opleiding Opleiding { get; set; }
        public Bestemming Bestemming { get; set; }
    }
}
