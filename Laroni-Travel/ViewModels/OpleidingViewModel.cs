using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class OpleidingViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
        private ObservableCollection<Opleiding> _opleidingen;
        private ObservableCollection<OpleidingBestemming> _bestemming;
        private ObservableCollection<DeelnemerOpleiding> _deelnemers;
        private ObservableCollection<OpleidingBestemming> _bestemmingen;
        private Opleiding _opleidingSelected;
        private Opleiding _opleidingRecord;
        private Bestemming _selectedBestemming;
        private string _beschrijving;
        private string _straatnaam;
        private string _huisnummer;
        private string _postcode;
        private string _gemeente;
        private string _land;
        private string _familienaam;
        private DateTime _datum;
        private int _maxAantalDeelenemrs;
        private Window _view;
        private Deelnemer _selectedDeelnemer;
        private Deelnemer _deelnemerRecord;
        private Bestemming _bestemmingRecord;
        private DeelnemerOpleiding _selectedDeelnemerOpleiding;
        public string ID { get; set; }
        private string _inlogEmail;
        private string _foutmelding;
        public ObservableCollection<Deelnemer> DeelnemersLijst { get; set; }     

        public OpleidingViewModel(Window view, string email)
        {
            InlogEmail = email;
            _view = view;
            OpleidingRecordInstellen();
            BestemmingRecordInstellen();
            Bestemmingen = new ObservableCollection<OpleidingBestemming>(_unitOfWork.OpleidingBestemmingenRepo.Ophalen(b => b.Bestemming));
            Bestemmingen.ToString();
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }

        public DeelnemerOpleiding SelectedDeelnemerOpleiding
        {
            get { return _selectedDeelnemerOpleiding; }
            set
            {
                _selectedDeelnemerOpleiding = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<OpleidingBestemming> Bestemmingen
        {
            get { return _bestemmingen; }
            set
            {
                _bestemmingen = value;                
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

        public Deelnemer DeelnemerRecord
        {
            get { return _deelnemerRecord; }
            set
            {
                _deelnemerRecord = value;
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

        public int MaxAantalDeelenemrs
        {
            get { return _maxAantalDeelenemrs; }
            set
            {
                _maxAantalDeelenemrs = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<DeelnemerOpleiding> Deelnemers 
        {
            get { return _deelnemers; }
            set { _deelnemers = value; 
            NotifyPropertyChanged();
            }
        }         

        public ObservableCollection<Opleiding> Opleidingen
        {
            get { return _opleidingen; }
            set
            {
                _opleidingen = value;
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

        public ObservableCollection<OpleidingBestemming> Bestemming
        {
            get { return _bestemming; }
            set
            {
                _bestemming = value;
                NotifyPropertyChanged();
            }
        }

        public Opleiding SelectedOpleiding
        {
            get { return _opleidingSelected; }
            set
            {
                _opleidingSelected = value;
                OpleidingRecordInstellen();
                NotifyPropertyChanged(nameof(SelectedOpleiding));
            }
        }

        public Opleiding OpleidingRecord
        {
            get { return _opleidingRecord; }
            set
            {
                _opleidingRecord = value;
                NotifyPropertyChanged();
            }
        }

        public string Beschrijving
        {
            get { return _beschrijving; }
            set
            {
                _beschrijving = value;
                NotifyPropertyChanged();
            }
        }

        public DateTime Datum
        {
            get { return _datum; }
            set
            {
                _datum = value;
                NotifyPropertyChanged();
            }
        }

        public override string this[string columnName]
        {
            get { return columnName; }
        }

        public override bool CanExecute(object parameter)
        {
            if (SelectedOpleiding == null)
            {
                switch (parameter.ToString())
                {
                    case "ToevoegenOpleiding": return true;
                    case "AanpassenOpleiding": return false;
                    case "VerwijderenOpleiding": return false;
                    case "ResettenOpleiding": return true;
                    case "OpenPersonenView": return true;
                    case "OpenReizenView": return true;
                    case "OpenHomeView": return true;
                    case "OpenInlogView": return true;
                    case "Zoeken": return true;
                    case "ZoekenDeelnemer": return true;
                    case "ToevoegenDeelnemerOpleiding": return false;
                    case "VerwijderenDeelnemerOpleiding": return true;
                }
            }
            else
            {
                switch (parameter.ToString())
                {
                    case "ToevoegenOpleiding": return false;
                    case "AanpassenOpleiding": return true;
                    case "VerwijderenOpleiding": return true;
                    case "ResettenOpleiding": return true;
                    case "OpenPersonenView": return true;
                    case "OpenReizenView": return true;
                    case "OpenHomeView": return true;
                    case "OpenInlogView": return true;
                    case "Zoeken": return true;
                    case "ZoekenDeelnemer": return true;
                    case "ToevoegenDeelnemerOpleiding": return true;
                    case "VerwijderenDeelnemerOpleiding": return true;
                }
            }
            
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenOpleiding": ToevoegenOpleiding(); break;
                case "AanpassenOpleiding": AanpassenOpleiding(); break;
                case "VerwijderenOpleiding": VerwijderenOpleiding(); break;
                case "ResettenOpleiding": ResettenOpleiding(); break;
                case "OpenPersonenView": OpenPersonenView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
                case "Zoeken": Zoeken(); break;
                case "ZoekenDeelnemer": ZoekenDeelnemer(); break;
                case "ToevoegenDeelnemerOpleiding": ToevoegenDeelnemerOpleiding(); break;
                case "VerwijderenDeelnemerOpleiding": VerwijderenDeelnemerOpleiding(); break;
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

        public void OpenReizenView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {                
               
                var view = new ReizenView();
                var vm = new ReizenViewModel(view, InlogEmail);
                view.DataContext = vm;
                view.Show();
                _view.Close();
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";

            RefreshOpleidingen();
            if (Opleidingen == null || Opleidingen.Count <= 0)
            {
                Foutmelding = "Er zijn geen Opleidingen gevonden";
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

        private void RefreshOpleidingen()
        {
            if (ID != null && ID != "")
            {
                Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen(o => o.OpleidingBestemmingen).Where(x => x.OpleidingId == int.Parse(ID)));
                Bestemming = new ObservableCollection<OpleidingBestemming>(_unitOfWork.OpleidingBestemmingenRepo.Ophalen(b => b.Bestemming));
                Deelnemers = new ObservableCollection<DeelnemerOpleiding>(_unitOfWork.DeelnemerOpleidingenRepo.Ophalen(d => d.Deelnemer).Where(d => d.OpleidingId == int.Parse(ID)));
            }
            else
            {
                Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen(o => o.OpleidingBestemmingen));
                Bestemming = new ObservableCollection<OpleidingBestemming>(_unitOfWork.OpleidingBestemmingenRepo.Ophalen(b => b.Bestemming));
            }           
            NotifyPropertyChanged(nameof(Opleidingen));
            NotifyPropertyChanged(nameof(Deelnemers));
            NotifyPropertyChanged(nameof(Bestemming));
            Foutmelding = "";
        }

        private void RefreshDeelnemer()
        {           
                DeelnemersLijst = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen(x => x.Familienaam.Contains(Familienaam)));
                NotifyPropertyChanged(nameof(DeelnemersLijst));                      
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshOpleidingen();
                ResettenOpleiding();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        public void ResettenOpleiding()
        {            
                SelectedOpleiding = null;
                OpleidingRecordInstellen();
                Foutmelding = "";
                NotifyPropertyChanged(nameof(SelectedOpleiding));                      
        }

        public void AanpassenOpleiding()
        {
            if (SelectedOpleiding != null)
            {
                _unitOfWork.OpleidingenRepo.Aanpassen(OpleidingRecord);
                int ok = _unitOfWork.Save();

                FoutmeldingInstellenNaSave(ok, "Opleiding is niet aangepast");
            }
            else
            {
                Foutmelding = "Selecteer een reis!";
            }
        }

        public void VerwijderenOpleiding()
        {
            if (SelectedOpleiding != null)
            {
                _unitOfWork.OpleidingenRepo.Verwijderen(SelectedOpleiding);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Opleiding is niet verwijderd");
            }
            else
            {
                Foutmelding = "Selecteer een reis!";
            }
        }

        public void ToevoegenOpleiding()
        {
            if (OpleidingRecord != null)
            {
                if (OpleidingRecord.IsGeldig())
                {                  
                    _unitOfWork.OpleidingenRepo.Toevoegen(OpleidingRecord);
                    int ok = _unitOfWork.Save();
                    FoutmeldingInstellenNaSave(ok, "Opleiding is niet toegevoegd");
                    Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen());
                    int i = Opleidingen.Count();
                    ID = i.ToString();
                    NotifyPropertyChanged(nameof(ID));
                    Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen(o => o.OpleidingBestemmingen).Where(o => o.OpleidingId == int.Parse(ID)));
                    NotifyPropertyChanged(nameof(Opleidingen));
                }
                else
                {
                    Foutmelding = OpleidingRecord.Error;
                }
            }           
            else
            {
                Foutmelding = "Selecteer een opleiding";
            }                
        }

        private void OpleidingRecordInstellen()
        {
            if (SelectedOpleiding != null)
            {
                OpleidingRecord = SelectedOpleiding;
                NotifyPropertyChanged(nameof(SelectedOpleiding));
            }
            else
            {
                OpleidingRecord = new Opleiding();
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

        public void VerwijderenDeelnemerOpleiding()
        {
            if (SelectedDeelnemerOpleiding != null)
            {
                _unitOfWork.DeelnemerOpleidingenRepo.Verwijderen(SelectedDeelnemerOpleiding.DeelnemerOpleidingId);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd uit opleiding");
            }
            else
            {
                Foutmelding = "Selecteer een deelnemer om te verwijderen uit opleiding";
            }
        }

        public void ToevoegenDeelnemerOpleiding()
        {
            if (DeelnemerRecord != null)
            {
                if (OpleidingRecord != null)
                {
                    if (DeelnemerRecord.IsGeldig())
                    {  
                        DeelnemerOpleiding deelnemerOpleiding = new DeelnemerOpleiding();
                        deelnemerOpleiding.Deelnemer = DeelnemerRecord;

                        if (ID != null)
                        {
                            deelnemerOpleiding.OpleidingId = int.Parse(ID);
                        }
                        else
                        {
                            deelnemerOpleiding.OpleidingId = OpleidingRecord.OpleidingId;
                        }
                        if (Deelnemers == null)
                        {
                            Deelnemers = new ObservableCollection<DeelnemerOpleiding>(_unitOfWork.DeelnemerOpleidingenRepo.Ophalen(d => d.Deelnemer).Where(d => d.OpleidingId == deelnemerOpleiding.OpleidingId));
                        }
                        else
                        {
                            foreach (var item in Deelnemers)
                            {
                                if (item.DeelnemerId == SelectedDeelnemer.DeelnemerId)
                                {
                                    Foutmelding = "Deelnemer is al bij opleiding toegevoegd";
                                }
                                else
                                {
                                    Foutmelding = "";
                                }                                
                            }
                            if (Foutmelding == "")
                            {
                                OpleidingRecord = SelectedOpleiding;
                                NotifyPropertyChanged(nameof(OpleidingRecord));
                                if (Deelnemers.Count() >= OpleidingRecord.MaxAantalDeelnemers)
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
                                _unitOfWork.DeelnemerOpleidingenRepo.Toevoegen(deelnemerOpleiding);
                                int ok = _unitOfWork.Save();
                                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
                            }
                        }                      
                    }
                }
                else
                {
                    Foutmelding = "Selecteer een opleiding om een deelnemer aan toe te voegen";
                }
            }
            else
            {
                Foutmelding = "Selecteer een deelnemer";
            }
        }
    }
}