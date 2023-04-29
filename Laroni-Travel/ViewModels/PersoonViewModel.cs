using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
//using Laroni_Travel.Models.Partials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class PersoonViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public ObservableCollection<Deelnemer> Deelnemers { get; set; }
        public Deelnemer DeelnemerRecord { get; set; }
        public string Foutmelding { get; set; }
        public string ID { get; set; }
        private Deelnemer _selectedDeelnemer;
        private int _deelnemerId;
        private string _voornaam;
        private string _familienaam;
        private string _email;
        private string _straatnaam;
        private string _huisnummer;
        private string _postcode;
        private string _gemeente;
        private DateTime _geboortedatum;
        private string _geslacht;
        private bool _ziekenfonds;
        private bool _monitor;
        private bool _hoofdMonitor;
        private bool _admin;

        public int DeelnemerId
        {
            get { return _deelnemerId; }
            set
            {
                _deelnemerId = value;
                NotifyPropertyChanged();
            }
        }
        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                _voornaam = value;
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
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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
        public DateTime Geboortedatum
        {
            get { return _geboortedatum; }
            set
            {
                _geboortedatum = value;
                NotifyPropertyChanged();
            }
        }
        public string Geslacht
        {
            get { return _geslacht; }
            set
            {
                _geslacht = value;
                NotifyPropertyChanged();
            }
        }
        public bool Ziekenfonds
        {
            get { return _ziekenfonds; }
            set
            {
                _ziekenfonds = value;
                NotifyPropertyChanged();
            }
        }
        public bool Monitor
        {
            get { return _monitor; }
            set
            {
                _monitor = value;
                NotifyPropertyChanged();
            }
        }
        public bool HoofdMonitor
        {
            get { return _hoofdMonitor; }
            set
            {
                _hoofdMonitor = value;
                NotifyPropertyChanged();
            }
        }
        public bool Admin
        {
            get { return _admin; }
            set
            {
                _admin = value;
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
                NotifyPropertyChanged("SelectedDeelnemer");
            }
        }

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "DeelnemerId" && !int.TryParse(ID, out int deelnemerId))
                {
                    return "deelnemerId moet een numerieke waarde zijn!" + Environment.NewLine;
                }
                return "";
            }
        }

        public PersoonViewModel() 
        {
            Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen());
            DeelnemerRecordInstellen();
        }

        public void Aanpassen()
        {
            if (SelectedDeelnemer != null)
            {
                if (IsGeldig())
                {
                    _unitOfWork.DeelnemersRepo.ToevoegenOfAanpassen(DeelnemerRecord);
                    int ok = _unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Deelnemer is niet aangepast");
                }
            }
            else
            {
                Foutmelding = "Selecteer een Deelnemer!";
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            if (IsGeldig())
            {
                RefreshDeelnemer();
                if (Deelnemers == null || Deelnemers.Count <= 0)
                {
                    Foutmelding = "Er zijn geen Deelnemer gevonden horende bij DeelnemerId " + ID;
                }
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        public void Verwijderen()
        {
            if (SelectedDeelnemer != null)
            {
                _unitOfWork.DeelnemersRepo.Verwijderen(SelectedDeelnemer.DeelnemerId);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Deelnemer selecteren";
            }
        }

        public void Toevoegen()
        {
            if (this.IsGeldig())
            {
                DeelnemerRecord.DeelnemerId = int.Parse(ID);
                if (IsGeldig())
                {
                    _unitOfWork.DeelnemersRepo.Toevoegen(DeelnemerRecord);
                    int ok = _unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
                }
            }
        }

        private void DeelnemerRecordInstellen()
        {
            if (SelectedDeelnemer != null)
            {
                DeelnemerRecord = SelectedDeelnemer;
            }
            else
            {
                DeelnemerRecord = new Deelnemer();
            }
        }

        public void Resetten()
        {
            if (this.IsGeldig())
            {
                SelectedDeelnemer = null;
                DeelnemerRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshDeelnemer();
                Resetten();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        private void RefreshDeelnemer()
        {
            int i = int.Parse(ID);
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.DeelnemerId == i).ToList();

            Deelnemers = new ObservableCollection<Deelnemer>(listDeelnemers);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen": return true;
                case "Aanpassen": return true;
                case "Verwijderen": return true;
                case "Zoeken": return true;
                case "Resetten": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Toevoegen": Toevoegen(); break;
                case "Aanpassen": Aanpassen(); break;
                case "Verwijderen": Verwijderen(); break;
                case "Zoeken": Zoeken(); break;
                case "Resetten": Resetten(); break;
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
