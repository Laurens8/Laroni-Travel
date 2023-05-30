using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.Models
{
    public partial class Groepsreis
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
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

        [Required]
        public int MaxAantalDeelnemers { get; set; }

        //Navigatieproperty
        public Bestemming Bestemming { get; set; }
        public LeeftijdsCategorie LeeftijdsCategorie { get; set; }
        public Thema Thema { get; set; }
        public ICollection<DeelnemerGroepsreis> DeelnemerGroepsreizen { get; set; }

        [NotMapped]
        public float Drinkgeld { get { return Prijs * 0.05f; } }

        [NotMapped]
        public string StartdatumInfo { get { return Startdatum.ToString("dd-MM-yyyy"); } }

        [NotMapped]
        public string EinddatumInfo { get { return Einddatum.ToString("dd-MM-yyyy"); } }

        [NotMapped]
        public string? AantalDeelnemers
        {
            get 
            { 
                if (DeelnemerGroepsreizen == null)
                { 
                    return "0 / " + MaxAantalDeelnemers.ToString();
                } 
                else 
                { 
                    return DeelnemerGroepsreizen.Count().ToString() + " / " + MaxAantalDeelnemers.ToString();
                } 
            }           
        }

        [NotMapped]
        public float PrijsZf { get { return Prijs * 0.9f; } }

        [NotMapped]
        public ObservableCollection<Groepsreis> AantalReizen { get { return new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen()); } }

        [NotMapped]
        public string TotaalReizen { get { return "Er zijn totaal " + AantalReizen.Count().ToString() + " aantal reizen geboekt"; } }
    }
}