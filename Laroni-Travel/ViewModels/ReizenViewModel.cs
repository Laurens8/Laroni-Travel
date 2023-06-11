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
        private ObservableCollection<DeelnemerGroepsreis> _Bestaald;
        private ObservableCollection<Bestemming> _bestemming;
        private Bestemming _bestemmingRecord;
        private Deelnemer _deelnemerRecord;
        private ObservableCollection<DeelnemerGroepsreis> _DeelnemersReisRecord;
        private float _drinkgeld;
        private DateTime _einddatum;
        private string _familienaam;
        private string _foutmelding;
        private string _gemeente;
        private string _huisnummer;
        private string _inlogEmail;
        private string _land;
        private ObservableCollection<LeeftijdsCategorie> _leeftijdsCategorie;
        private int _maxAantalDeelenemrs;
        private string _naam;
        private string _postcode;
        private float _prijs;
        private float _prijsZf;
        private int _reisId;
        private Groepsreis _reisRecord;
        private ObservableCollection<Groepsreis> _reizen;
        private Bestemming _selectedBestemming;
        private Deelnemer _selectedDeelnemer;
        private DeelnemerGroepsreis _selectedDeelnemerReis;
        private Groepsreis _selectedGroepsreis;
        private DateTime _startdatum;
        private string _straatnaam;
        private ObservableCollection<Thema> _thema;
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
        private Window _view;

        public ReizenViewModel(Window view, string email)
        {
            ReizenRecordInstellen();
            InlogEmail = email;
            _view = view;
            Thema = new ObservableCollection<Thema>(_unitOfWork.ThemasRepo.Ophalen());
            LeeftijdsCategorie = new ObservableCollection<LeeftijdsCategorie>(_unitOfWork.LeeftijdsCategorieenRepo.Ophalen());
            Bestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingenRepo.Ophalen());
            Bestemming.ToString();
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

        public Bestemming BestemmingRecord
        {
            get { return _bestemmingRecord; }
            set
            {
                _bestemmingRecord = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<DeelnemerGroepsreis> Betaald
        {
            get { return _Bestaald; }
            set
            {
                _Bestaald = value;
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

        public int Deelnemers { get; set; }

        public ObservableCollection<DeelnemerGroepsreis> DeelnemersInschrijven
        {
            get { return _DeelnemersReisRecord; }
            set
            {
                _DeelnemersReisRecord = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Deelnemer> DeelnemersLijst { get; set; }

        public float Drinkgeld
        {
            get { return _drinkgeld; }
            set
            {
                _drinkgeld = value;
                NotifyPropertyChanged();
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

        public string Familienaam
        {
            get { return _familienaam; }
            set
            {
                _familienaam = value;
                NotifyPropertyChanged();
            }
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

        public string Gemeente
        {
            get { return _gemeente; }
            set
            {
                _gemeente = value;
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

        public string ID { get; set; }

        public string InlogEmail
        {
            get { return _inlogEmail; }
            set
            {
                _inlogEmail = value;
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

        public ObservableCollection<LeeftijdsCategorie> LeeftijdsCategorie
        {
            get { return _leeftijdsCategorie; }
            set
            {
                _leeftijdsCategorie = value;
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

        public string Naam
        {
            get { return _naam; }
            set
            {
                _naam = value;
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

        public float Prijs
        {
            get { return _prijs; }
            set
            {
                _prijs = value;
                NotifyPropertyChanged();
            }
        }

        public float PrijsZf
        {
            get { return _prijsZf; }
            set
            {
                _prijsZf = value;
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

        public Groepsreis ReisRecord
        {
            get { return _reisRecord; }
            set
            {
                _reisRecord = value;
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

        public Bestemming SelectedBestemming
        {
            get { return _selectedBestemming; }
            set
            {
                _selectedBestemming = value;
                BestemmingRecordInstellen();
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

        public DeelnemerGroepsreis SelectedDeelnemerReis
        {
            get { return _selectedDeelnemerReis; }
            set
            {
                _selectedDeelnemerReis = value;
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

        public DateTime Startdatum
        {
            get { return _startdatum; }
            set
            {
                _startdatum = value;
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

        public ObservableCollection<Thema> Thema
        {
            get { return _thema; }
            set
            {
                _thema = value;
                NotifyPropertyChanged();
            }
        }

        public override string this[string columnName]
        {
            get { return columnName; }
        }

        public void AanpassenGroepsreis()
        {
            if (SelectedGroepsreis != null)
            {
                if (ReisRecord.IsGeldig())
                {
                    _unitOfWork.GroepsreisenRepo.Aanpassen(ReisRecord);
                    int ok = _unitOfWork.Save();
                    FoutmeldingInstellenNaSave(ok, "Groepsreis is niet aangepast");
                }
            }
            else
            {
                Foutmelding = "Selecteer een reis";
            }
        }

        public void BetalingOpslaan()
        {
            if (SelectedDeelnemerReis != null)
            {
                _unitOfWork.DeelnemerGroepsreisenRepo.ToevoegenOfAanpassen(SelectedDeelnemerReis);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Betaling van deelnemer is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een deelnemer om de betaling aan te passen";
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (SelectedGroepsreis == null)
            {
                switch (parameter.ToString())
                {
                    case "ToevoegenGroepsreis": return true;
                    case "AanpassenGroepsreis": return false;
                    case "VerwijderenGroepsreis": return false;
                    case "BetalingOpslaan": return false;
                    case "Zoeken": return true;
                    case "ResettenGroepsreis": return true;
                    case "OpenOpleidingView": return true;
                    case "OpenPersonenView": return true;
                    case "OpenHomeView": return true;
                    case "OpenInlogView": return true;
                    case "ZoekenDeelnemer": return true;
                    case "ToevoegenDeelnemerReis": return false;
                    case "VerwijderenDeelnemerReis": return false;
                }
            }
            else
            {
                switch (parameter.ToString())
                {
                    case "ToevoegenGroepsreis": return false;
                    case "AanpassenGroepsreis": return true;
                    case "VerwijderenGroepsreis": return true;
                    case "BetalingOpslaan": return true;
                    case "Zoeken": return true;
                    case "ResettenGroepsreis": return true;
                    case "OpenOpleidingView": return true;
                    case "OpenPersonenView": return true;
                    case "OpenHomeView": return true;
                    case "OpenInlogView": return true;
                    case "ZoekenDeelnemer": return true;
                    case "ToevoegenDeelnemerReis": return true;
                    case "VerwijderenDeelnemerReis": return true;
                }
            }

            return true;
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenGroepsreis": ToevoegenGroepsreis(); break;
                case "AanpassenGroepsreis": AanpassenGroepsreis(); break;
                case "VerwijderenGroepsreis": VerwijderenGroepsreis(); break;
                case "BetalingOpslaan": BetalingOpslaan(); break;
                case "Zoeken": Zoeken(); break;
                case "ResettenGroepsreis": ResettenGroepreis(); break;
                case "OpenOpleidingView": OpenOpleidingView(); break;
                case "OpenPersonenView": OpenPersonenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
                case "ZoekenDeelnemer": ZoekenDeelnemer(); break;
                case "ToevoegenDeelnemerReis": ToevoegenDeelnemerReis(); break;
                case "VerwijderenDeelnemerReis": VerwijderenDeelnemerReis(); break;
            }
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
            SelectedGroepsreis = null;
            ReizenRecordInstellen();
            Foutmelding = "";
            NotifyPropertyChanged(nameof(SelectedGroepsreis));
        }

        public void ToevoegenDeelnemerReis()
        {
            if (DeelnemerRecord != null)
            {
                if (ReisRecord != null)
                {
                    if (DeelnemerRecord.IsGeldig())
                    {
                        DeelnemerGroepsreis deelnemerGroepsreis = new DeelnemerGroepsreis();
                        deelnemerGroepsreis.DeelnemerId = SelectedDeelnemer.DeelnemerId;
                        if (ID != "" && ID != null)
                        {
                            deelnemerGroepsreis.GroepsreisId = int.Parse(ID);
                        }
                        else
                        {
                            deelnemerGroepsreis.GroepsreisId = ReisRecord.GroepsreisId;
                        }
                        if (DeelnemerRecord.HoofdMonitor == true)
                        {
                            deelnemerGroepsreis.RolId = 3;
                        }
                        else if (DeelnemerRecord.Monitor == true)
                        {
                            deelnemerGroepsreis.RolId = 2;
                        }
                        else
                        {
                            deelnemerGroepsreis.RolId = 1;
                        }
                        if (DeelnemersInschrijven == null)
                        {
                            DeelnemersInschrijven = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen(x => x.GroepsreisId == deelnemerGroepsreis.GroepsreisId));
                        }
                        else
                        {
                            foreach (var item in DeelnemersInschrijven)
                            {
                                if (item.DeelnemerId == SelectedDeelnemer.DeelnemerId)
                                {
                                    Foutmelding = "Deelnemer is al bij reis toegevoegd";
                                }
                                else
                                {
                                    Foutmelding = "";
                                }
                            }
                            if (Foutmelding == "")
                            {
                                ReisRecord = SelectedGroepsreis;
                                NotifyPropertyChanged(nameof(ReisRecord));
                                if (DeelnemersInschrijven.Count() >= ReisRecord.MaxAantalDeelnemers)
                                {
                                    Foutmelding = "Max aantal deelnemers bereikt";
                                }
                                else
                                {
                                    Foutmelding = "";
                                }
                            }

                            if (Foutmelding == "")
                            {
                                _unitOfWork.DeelnemerGroepsreisenRepo.Toevoegen(deelnemerGroepsreis);
                                int ok = _unitOfWork.Save();
                                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
                            }
                        }
                    }
                }
                else
                {
                    Foutmelding = "Selecteer een reis om een deelnemer aan toe te voegen";
                }
            }
            else
            {
                Foutmelding = "Selecteer een deelnemer";
            }
        }

        public void ToevoegenGroepsreis()
        {
            if (ReisRecord != null)
            {
                if (ReisRecord.Thema != null)
                {
                    if (ReisRecord.LeeftijdsCategorie != null)
                    {
                        if (ReisRecord.Bestemming != null)
                        {
                            if (ReisRecord.IsGeldig() && ReisRecord.Bestemming.IsGeldig())
                            {
                                _unitOfWork.GroepsreisenRepo.Toevoegen(ReisRecord);
                                int ok = _unitOfWork.Save();
                                FoutmeldingInstellenNaSave(ok, "Groepsreis is niet toegevoegd");
                                Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen());
                                int i = Reizen.Count();
                                ID = i++.ToString();
                                Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen().Where(r => r.GroepsreisId == int.Parse(ID)));
                                DeelnemersInschrijven = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen().Where(r => r.GroepsreisId == int.Parse(ID)));
                                NotifyPropertyChanged(nameof(Reizen));
                                NotifyPropertyChanged(nameof(ID));
                            }
                            else
                            {
                                Foutmelding = ReisRecord.Error;
                                Foutmelding = ReisRecord.Bestemming.Error;
                            }
                        }
                        else
                        {
                            Foutmelding = "Selecteer een bestemming";
                        }
                    }
                    else
                    {
                        Foutmelding = "Selecteer een leeftijdsCategorie";
                    }
                }
                else
                {
                    Foutmelding = "Selecteer een thema";
                }
            }
            else
            {
                Foutmelding = "Groepsreis is niet toegevoegd";
            }
        }

        public void VerwijderenDeelnemerReis()
        {
            if (SelectedDeelnemerReis != null)
            {
                _unitOfWork.DeelnemerGroepsreisenRepo.Verwijderen(SelectedDeelnemerReis.DeelnemerGroepsreisId);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd uit reis");
            }
            else
            {
                Foutmelding = "Selecteer een deelnemer om te verwijderen uit reis";
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
                Foutmelding = "Selecteer een reis";
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

        private void BestemmingRecordInstellen()
        {
            if (SelectedBestemming != null)
            {
                BestemmingRecord = SelectedBestemming;
                NotifyPropertyChanged(nameof(SelectedBestemming));
            }
            else
            {
                BestemmingRecord = new Bestemming();
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

        private void RefreshDeelnemer()
        {
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Familienaam.Contains(Familienaam)).ToList();
            DeelnemersLijst = new ObservableCollection<Deelnemer>(listDeelnemers);
            NotifyPropertyChanged(nameof(DeelnemersLijst));
        }

        private void RefreshReizen()
        {
            if (ID != null && ID != "")
            {
                Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen(r => r.GroepsreisId == int.Parse(ID)));
                DeelnemersInschrijven = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen(d => d.Deelnemer).Where(d => d.GroepsreisId == int.Parse(ID)));
                Betaald = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen(b => b.Betaald).Where(b => b.GroepsreisId == int.Parse(ID)));
            }
            else
            {
                Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen());
                Betaald = new ObservableCollection<DeelnemerGroepsreis>(_unitOfWork.DeelnemerGroepsreisenRepo.Ophalen());
            }
            Bestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingenRepo.Ophalen());
            Thema = new ObservableCollection<Thema>(_unitOfWork.ThemasRepo.Ophalen());
            LeeftijdsCategorie = new ObservableCollection<LeeftijdsCategorie>(_unitOfWork.LeeftijdsCategorieenRepo.Ophalen());

            Thema.ToString();
            LeeftijdsCategorie.ToString();
            Deelnemers.ToString();
            NotifyPropertyChanged(nameof(Reizen));
            Foutmelding = "";
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
    }
}