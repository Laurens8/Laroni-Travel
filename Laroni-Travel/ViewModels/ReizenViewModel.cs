using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace Laroni_Travel.ViewModels
{
    public class ReizenViewModel : BaseViewmodel, IDisposable, ICommand
    {
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenGroepsreis": return true;
                case "AanpassenGroepsreis": return true;
                case "VerwijderenGroepsreis": return true;
                case "Zoeken": return true;
                case "ResettenGroepsreis": return true;
                case "OpenOpleidingView": return true;
                case "OpenPersonenView": return true;
                case "OpenHomeView": return true;
                case "OpenInlogView": return true;
                case "ZoekenDeelnemer": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenDeelnemer": ToevoegenGroepsreis(); break;
                case "AanpassenDeelnemer": AanpassenGroepsreis(); break;
                case "VerwijderenDeelnemer": VerwijderenGroepsreis(); break;
                case "Zoeken": Zoeken(); break;
                case "ResettenDeelnemer": ResettenGroepreis(); break;
                case "OpenOpleidingView": OpenOpleidingView(); break;
                case "OpenPersonenView": OpenPersonenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
                case "ZoekenDeelnemer": ZoekenDeelnemer(); break;
            }
        }
        private float _drinkgeld;
        private string _naam;
        private string _straatnaam;
        private string _huisnummer;
        private string _postcode;
        private string _gemeente;
        private string _land;
        private int _groepsreisId;
        private int _bestemmingId;
        private int _themaId;
        private int _leeftijdsCategorieId;  
        private DateTime _einddatum;
        private DateTime _startdatum;
        private ObservableCollection<Thema> _thema;
        private int _reisId;
        private float _prijs;
        private int _maxAantalDeelenemrs;
        private string _familienaam;
        public string ID { get; set; }
        private string _foutmelding;
        private Deelnemer _deelnemerRecord;
        private Deelnemer _selectedDeelnemer;
        private Groepsreis _selectedGroepsreis;
        private Groepsreis _reisRecord;
        private ObservableCollection<Groepsreis> _reizen;
        private ObservableCollection<DeelnemerGroepsreis> _DeelnemersReisRecord;
        private ObservableCollection<LeeftijdsCategorie> _leeftijdsCategorie;
        private ObservableCollection<Bestemming> _bestemming;
        public ObservableCollection<Deelnemer> DeelnemersLijst { get; set; }
        public int Deelnemers { get; set; }
        private string _inlogEmail;
        private Window _view;
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());

        public ReizenViewModel(Window view, string email)
        {            
            InlogEmail = email;
            _view = view;
            ReizenRecordInstellen();
        }

        public string Foutmelding
        {
            get { return _foutmelding; }
            set
            {
                _foutmelding = value;
                NotifyPropertyChanged();
            }
        }

        public string InlogEmail
        {
            get { return _inlogEmail; }
            set
            {
                _inlogEmail = value;
                NotifyPropertyChanged();
            }
        }

        public string Familienaam
        {
            get { return _familienaam; }
            set
            {
                _familienaam = value;
                NotifyPropertyChanged();
            }
        }
        
        public int MaxAantalDeelenemrs
        {
            get { return _maxAantalDeelenemrs; }
            set
            {
                _maxAantalDeelenemrs = value;
                NotifyPropertyChanged();
            }
        }

        public Deelnemer SelectedDeelnemer
        {
            get { return _selectedDeelnemer; }
            set
            {
                _selectedDeelnemer = value;
                DeelnemerRecordInstellen();
                NotifyPropertyChanged();
            }
        }

        public Deelnemer DeelnemerRecord
        {
            get { return _deelnemerRecord; }
            set
            {
                _deelnemerRecord = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<DeelnemerGroepsreis> DeelnemersRecord
        {
            get { return _DeelnemersReisRecord; }
            set
            {
                _DeelnemersReisRecord = value;
                NotifyPropertyChanged();
            }
        }     

        public ObservableCollection<LeeftijdsCategorie> LeeftijdsCategorie
        {
            get { return _leeftijdsCategorie; }
            set
            {
                _leeftijdsCategorie = value;
                NotifyPropertyChanged();
            }
        }      

        public float Drinkgeld
        {
            get { return _drinkgeld; }
            set
            {
                _drinkgeld = value;
                NotifyPropertyChanged();
            }
        }

        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = value;
                NotifyPropertyChanged();
            }
        }

        public string Straatnaam
        {
            get { return _straatnaam; }
            set
            {
                _straatnaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Huisnummer
        {
            get { return _huisnummer; }
            set
            {
                _huisnummer = value;
                NotifyPropertyChanged();
            }
        }

        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
                NotifyPropertyChanged();
            }
        }

        public string Gemeente
        {
            get { return _gemeente; }
            set
            {
                _gemeente = value;
                NotifyPropertyChanged();
            }
        }

        public string Land
        {
            get { return _land; }
            set
            {
                _land = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Bestemming> Bestemming
        {
            get { return _bestemming; }
            set
            {
                _bestemming = value;
                NotifyPropertyChanged();
            }
        }

        public int GroepsreisId
        {
            get { return _groepsreisId; }
            set
            {
                _groepsreisId = value;
                NotifyPropertyChanged();
            }
        }

        public int BestemmingId
        {
            get { return _bestemmingId; }
            set
            {
                _bestemmingId = value;
                NotifyPropertyChanged();
            }
        }

        public int ThemaId
        {
            get { return _themaId; }
            set
            {
                _themaId = value;
                NotifyPropertyChanged();
            }
        }

        public int LeeftijdsCategorieId
        {
            get { return _leeftijdsCategorieId; }
            set
            {
                _leeftijdsCategorieId = value;
                NotifyPropertyChanged();
            }
        }

        public float Prijs
        {
            get { return _prijs; }
            set
            {
                _prijs = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Groepsreis> Reizen
        {
            get { return _reizen; }
            set
            {
                _reizen = value;
                NotifyPropertyChanged();
            }
        }

        public Groepsreis ReisRecord
        {
            get { return _reisRecord; }
            set
            {
                _reisRecord = value;
                NotifyPropertyChanged();
            }
        }

        public Groepsreis SelectedGroepsreis
        {
            get { return _selectedGroepsreis; }
            set
            {
                _selectedGroepsreis = value;
                ReizenRecordInstellen();
                NotifyPropertyChanged(nameof(SelectedGroepsreis));
            }
        }

        public DateTime Einddatum
        {
            get { return _einddatum; }
            set
            {
                _einddatum = value;
                NotifyPropertyChanged();
            }
        }
        public DateTime Startdatum
        {
            get { return _startdatum; }
            set
            {
                _startdatum = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Thema> Thema
        {
            get { return _thema; }
            set
            {
                _thema = value;
                NotifyPropertyChanged();
            }
        }
        public int ReisId
        {
            get { return _reisId; }
            set
            {
                _reisId = value;
                NotifyPropertyChanged();
            }
        }

        public override string this[string columnName]
        {
            get { return columnName; }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            
            RefreshReizen();           
            if (Reizen == null || Reizen.Count <= 0)
            {
                Foutmelding = "Er zijn geen reizen gevonden";
            }            
        }

        public void ZoekenDeelnemer()
        {
            Foutmelding = "";
            RefreshDeelnemer();
            if (DeelnemersLijst == null || DeelnemersLijst.Count <= 0)
            {
                Foutmelding = "Er zijn geen deelnemers gevonden";
            }            
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        private void RefreshReizen()
        {
            Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen(r => r.GroepsreisId == int.Parse(ID)));
            Bestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingenRepo.Ophalen());
            Thema = new ObservableCollection<Thema>(_unitOfWork.ThemasRepo.Ophalen());
            LeeftijdsCategorie = new ObservableCollection<LeeftijdsCategorie>(_unitOfWork.LeeftijdsCategorieenRepo.Ophalen());
            DeelnemersRecord = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen(d => d.Deelnemer).Where(d => d.GroepsreisId == int.Parse(ID)));
            Thema.ToString();
            LeeftijdsCategorie.ToString();
            Deelnemers.ToString();
            NotifyPropertyChanged(nameof(Reizen));
            Foutmelding = "";
        }

        private void RefreshDeelnemer()
        {
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Familienaam.Contains(Familienaam)).ToList();            
            DeelnemersLijst = new ObservableCollection<Deelnemer>(listDeelnemers);
            NotifyPropertyChanged(nameof(DeelnemersLijst));
        }

        public void OpenHomeView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new HomeView();
                var vm = new HomeViewModel(view, InlogEmail);
                
                view.DataContext = vm;
                view.Show();
               _view.Close();
            }
        }

        public void OpenInlogView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new InlogView();
                var vm = new InlogViewModel(view, "");
              
                view.DataContext = vm;
                view.Show();
                _view.Close();
            }
        }

        public void OpenOpleidingView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new OpleidingView();
                var vm = new OpleidingViewModel(view, InlogEmail);
                
                view.DataContext = vm;
                view.Show();
                _view.Close();
            }
        }

        public void OpenPersonenView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new PersoonView();
                var vm = new PersoonViewModel(view, InlogEmail);
                
                view.DataContext = vm;
                view.Show();
               _view.Close();
            }
        }

        public void ResettenGroepreis()
        {
            if (SelectedGroepsreis != null)
            {
                SelectedGroepsreis = null;
                ReizenRecordInstellen();
                Foutmelding = "";
                NotifyPropertyChanged(nameof(SelectedGroepsreis));
            }
            else
            {
                Foutmelding = "Selecteer een reis!";
            }
                 
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshReizen();
                ResettenGroepreis();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        public void AanpassenGroepsreis()
        {
            if (SelectedGroepsreis != null)
            {
                _unitOfWork.GroepsreisenRepo.Aanpassen(ReisRecord);
                int ok = _unitOfWork.Save();

                FoutmeldingInstellenNaSave(ok, "Groepsreis is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een reis!";
            }
        }

        public void VerwijderenGroepsreis()
        {
            if (SelectedGroepsreis != null)
            {
                _unitOfWork.GroepsreisenRepo.Verwijderen(SelectedGroepsreis);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Groepsreis is niet verwijderd");
            }
            else
            {
                Foutmelding = "Selecteer een reis!";
            }
        }

        public void ToevoegenGroepsreis()
        {
            try
            {
                _unitOfWork.GroepsreisenRepo.Toevoegen(ReisRecord);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Groepsreis is niet toegevoegd");
            }
            catch (Exception)
            {
                Foutmelding = "Groepsreis is niet toegevoegd";
            }
            
        }

        private void ReizenRecordInstellen()
        {
            if (SelectedGroepsreis != null)
            {
                ReisRecord = SelectedGroepsreis;
                NotifyPropertyChanged(nameof(SelectedGroepsreis));
            }
            else
            {
                ReisRecord = new Groepsreis();
            }
        }

        private void DeelnemerRecordInstellen()
        {
            if (SelectedDeelnemer != null)
            {
                DeelnemerRecord = SelectedDeelnemer;
                NotifyPropertyChanged(nameof(SelectedDeelnemer));
            }
            else
            {
                DeelnemerRecord = new Deelnemer();
            }
        }
    }
}