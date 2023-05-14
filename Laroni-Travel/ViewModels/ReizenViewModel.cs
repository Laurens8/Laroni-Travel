using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.Models.Partials;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
                case "OpenReizenView": return true;
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
                case "OpenPersoonView": OpenOpleidingView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;           
            }
        }

        private int _groepsreisId;
        private int _bestemmingId;
        private int _themaId;
        private int _leeftijdsCategorieId;
        private string _bestemming;        
        private DateTime _einddatum;
        private DateTime _startdatum;
        private string _thema;
        private int _reisId;
        private float _prijs;
        public string ID { get; set; }
        public string Foutmelding { get; set; }
        private Groepsreis _selectedGroepsreis;
        private Groepsreis _reisRecord;
        private ObservableCollection<Groepsreis> _reizen;
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public ReizenViewModel()
        {
            ReizenRecordInstellen();
            Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen());
        }

        public ReizenViewModel(Groepsreis groepsreis)
        {
            ReizenRecordInstellen();
            Reizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen());
            SelectedGroepsreis = groepsreis;
        }

        private void ReizenRecordInstellen()
        {
            ReisRecord = new Groepsreis();
            ReisRecord.Bestemming = new Bestemming();
            ReisRecord.Thema = new Thema();
            ReisRecord.LeeftijdsCategorieen = new LeeftijdsCategorie();
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
                NotifyPropertyChanged();
            }
        }

        public string Bestemming
        {
            get { return _bestemming; }
            set
            {
                _bestemming = value;
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
        public DateTime Startdatum
        {
            get { return _startdatum; }
            set
            {
                _startdatum = value;
                NotifyPropertyChanged();
            }
        }
        public string Titel
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
            //if (IsGeldig())
            //{
            RefreshReizen();
            if (Reizen == null || Reizen.Count <= 0)
            {
                Foutmelding = "Er zijn geen reizen gevonden";
            }           
            //}
            //else
            //{
            Foutmelding = this.Error;
            //}
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        private void RefreshReizen()
        {
            List<Groepsreis> listReizen = (List<Groepsreis>)_unitOfWork.MedischeRepo.Ophalen(x => x.DeelnemerId == int.Parse(ID));

            Reizen = new ObservableCollection<Groepsreis>(listReizen);
            NotifyPropertyChanged(nameof(Reizen));
        }

        public bool IsNumeriek(string input)
        {
            bool isNumeriek;
            if (input.All(char.IsDigit))
            {
                return isNumeriek = true;
            }
            else
            {
                return isNumeriek = false;
            }
        }

        public void OpenHomeView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var vm = new HomeViewModel();
                var view = new HomeView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public void OpenInlogView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var vm = new InlogViewModel();
                var view = new InlogView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public void OpenOpleidingView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var vm = new OpleidingViewModel();
                var view = new OpleidingView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public void OpenReizenView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var vm = new ReizenViewModel();
                var view = new ReizenView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public void ResettenGroepreis()
        {
            //if (this.IsGeldig())
            //{
            SelectedGroepsreis = null;
            ReizenRecordInstellen();
            Foutmelding = "";
            NotifyPropertyChanged(nameof(SelectedGroepsreis));
            //}
            //else
            //{
            //    Foutmelding = this.Error;
            //}
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
                if (IsGeldig())
                {
                    _unitOfWork.GroepsreisenRepo.Aanpassen(ReisRecord);
                    int ok = _unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Groepsreis is niet aangepast");
                }
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
            if (IsGeldig())
            {
                _unitOfWork.GroepsreisenRepo.Toevoegen(ReisRecord);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Groepsreis is niet toegevoegd");
            }
        }
    }
}