using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public class DeelnemerGroepsreis
    {
        [Key]
        public int DeelnemerGroepsreisId { get; set; }
        [Required]
        public int DeelnemerId { get; set; }
        [Required]
        public int GroepsreisId { get; set; }
        [Required]
        public int RolId { get; set; }

        public ICollection<Deelnemer> Deelnemer { get; set; }
        public Groepsreis Groepsreis { get; set; }
        public Rol Rol { get; set; }
    }
}
