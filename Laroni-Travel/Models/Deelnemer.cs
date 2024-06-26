﻿using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Laroni_Travel.Models
{
    public partial class Deelnemer
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());

        [Key]
        public int DeelnemerId { get; set; }

        [Required]
        public bool Admin { get; set; }
      

        [Required]
        public string Email { get; set; }

        [Required]
        public string Familienaam { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Geboortedatum { get; set; }
       
        [Required]
        public string Gemeente { get; set; }

        [Required]
        public string Geslacht { get; set; }

        [Required]
        public bool HoofdMonitor { get; set; }

        [Required]
        public string Huisnummer { get; set; }
       
        [Required]
        public bool Monitor { get; set; }

        [Required]
        public string Postcode { get; set; }

        [Required]
        public string Straatnaam { get; set; }
      
        [Required]
        public string Voornaam { get; set; }

        public string? Wachtwoord { get; set; }

        [Required]
        public bool Ziekenfonds { get; set; }

        [NotMapped]
        public ObservableCollection<Deelnemer> AantalDeelnemers
        { get { return new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen()); } }

        [NotMapped]
        public string totaaldeelnemers
        { get { return "Er zijn totaal " + AantalDeelnemers.Count().ToString() + " deelnemers ingeschreven in de reisbureau"; } }

        [NotMapped]
        public string VolledigeNaam
        { get { return $"{Voornaam} {Familienaam}"; } }

        [NotMapped]
        public string GeboortedatumInfo
        { get { return Geboortedatum.ToString("dd-MM-yyyy"); } }

        [NotMapped]
        public int Leeftijd
        { get { return DateTime.Now.Year - Geboortedatum.Year; } }

        //Navigatieproperty
        public ICollection<DeelnemerGroepsreis> DeelnemerGroepsreizen { get; set; }
        public ICollection<DeelnemerOpleiding> DeelnemerOpleidingen { get; set; }
        public ICollection<Medisch> Medische { get; set; }
    }
}