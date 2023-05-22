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
        private ObservableCollection<Bestemming> _bestemming;
        private DateTime _einddatum;
        private DateTime _startdatum;
        private ObservableCollection<Thema> _thema;
        private int _reisId;
        private float _prijs;
        public string ID { get; set; }
        public string Foutmelding { get; set; }
        private Groepsreis _selectedGroepsreis;
        private Groepsreis _reisRecord;
        private ObservableCollection<Groepsreis> _reizen;
        private ObservableCollection<DeelnemerGroepsreis> _DeelnemersReisRecord;
        private ObservableCollection<LeeftijdsCategorie> _leeftijdsCategorie;
        public int Deelnemers { get; set; }
        private Window _view;
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());

        public ReizenViewModel(Window view)
        {
            _view = view;
            ReizenRecordInstellen();
        }

        public void AantalDeelnemers()
        {
            foreach (var item in Reizen)
            {
                foreach (var item2 in DeelnemersRecord)
                {
                    if (item.GroepsreisId == item2.GroepsreisId)
                    {
                        Deelnemers++;
                    }
                }
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
            get
            {
                return "";
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            
            RefreshReizen();
            if (Reizen == null || Reizen.Count <= 0)
            {
                Foutmelding = "Er zijn geen reizen gevonden";
            }
            else           
            {
            Foutmelding = this.Error;
            }
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        private void RefreshReizen()
        {
            //List<Groepsreis> listReizen = (List<Groepsreis>)_unitOfWork.GroepsreisenRepo.Ophalen(x => x.GroepsreisId == int.Parse(ID));
            Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen(r => r.LeeftijdsCategorieId == int.Parse(ID)));
            Bestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingenRepo.Ophalen());
            Thema = new ObservableCollection<Thema>(_unitOfWork.ThemasRepo.Ophalen());
            LeeftijdsCategorie = new ObservableCollection<LeeftijdsCategorie>(_unitOfWork.LeeftijdsCategorieenRepo.Ophalen());
            DeelnemersRecord = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen());
            Deelnemers = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen()).Count();
            Thema.ToString();
            LeeftijdsCategorie.ToString();
            Drinkgeld = Prijs * 0.5f;
            Deelnemers.ToString();
            //Reizen = new ObservableCollection<Groepsreis>(listReizen);
            NotifyPropertyChanged(nameof(Reizen));
        }        

        public void OpenHomeView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new HomeView();
                var vm = new HomeViewModel(view);
                
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
                var vm = new InlogViewModel(view);
              
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
                var vm = new OpleidingViewModel(view);
                
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
                var vm = new PersoonViewModel(view);
                
                view.DataContext = vm;
                view.Show();
               _view.Close();
            }
        }

        public void ResettenGroepreis()
        {            
            SelectedGroepsreis = null;
            ReizenRecordInstellen();
            Foutmelding = "";
            NotifyPropertyChanged(nameof(SelectedGroepsreis));
                                   
            //Foutmelding = this.Error;
            
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
            _unitOfWork.GroepsreisenRepo.Toevoegen(ReisRecord);
            int ok = _unitOfWork.Save();
            FoutmeldingInstellenNaSave(ok, "Groepsreis is niet toegevoegd");
        }

        public float BerekenenPrijs(float input)
        {
            float output = 0;
            output = input * 0.05f;
            return output;
        }
    }
}