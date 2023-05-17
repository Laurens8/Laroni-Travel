﻿using Castle.Core.Internal;
using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;

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
        private string _omschrijving;
        private string _medicatie;
        private string _behandeling;
        private bool _admin;
        private int _deelnemerId;
        private Deelnemer _deelnemerRecord;
        private Medisch _medischRecord;
        private string _email;
        private string _familienaam;
        private DateTime _geboortedatum;
        private string _gemeente;
        private string _geslacht;
        private bool _hoofdMonitor;
        private string _huisnummer;
        private bool _monitor;
        private string _postcode;
        private Deelnemer _selectedDeelnemer;
        private Medisch _selectedMedisch;
        private string _straatnaam;
        public string ID { get; set; }
        public ObservableCollection<Deelnemer> Deelnemers { get; set; }
        public ObservableCollection<Medisch> MedischLijst { get; set; }
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());

        private string _voornaam = "";
        private bool _ziekenfonds;

        public PersoonViewModel()
        {
            Geboortedatum = DateTime.Now;
            Voornaam = "";
            DeelnemerRecordInstellen();
            MedischRecordInstellen();
        }

        public string Omschrijving
        {
            get { return _omschrijving; }
            set
            {
                _omschrijving = value;
                NotifyPropertyChanged();
            }
        }

        public string Medicatie
        {
            get { return _medicatie; }
            set
            {
                _medicatie = value;
                NotifyPropertyChanged();
            }
        }

        public string Behandeling
        {
            get { return _behandeling; }
            set
            {
                _behandeling = value;
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

        public int DeelnemerId
        {
            get { return _deelnemerId; }
            set
            {
                _deelnemerId = value;
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

        public Medisch MedischRecord
        {
            get { return _medischRecord; }
            set
            {
                _medischRecord = value;
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

        public string Familienaam
        {
            get { return _familienaam; }
            set
            {
                _familienaam = value;
                NotifyPropertyChanged();
            }
        }

        public string Foutmelding { get; set; }

        public DateTime Geboortedatum
        {
            get { return _geboortedatum; }
            set
            {
                _geboortedatum = value;
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

        public string Geslacht
        {
            get { return _geslacht; }
            set
            {
                _geslacht = value;
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

        public string Huisnummer
        {
            get { return _huisnummer; }
            set
            {
                _huisnummer = value;
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

        public string Postcode
        {
            get { return _postcode; }
            set
            {
                _postcode = value;
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

        public Medisch SelectedMedisch
        {
            get { return _selectedMedisch; }
            set
            {
                _selectedMedisch = value;
                MedischRecordInstellen();
                NotifyPropertyChanged("SelectedMedisch");
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

        public string Voornaam
        {
            get { return _voornaam; }
            set
            {
                _voornaam = value;
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

        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Voornaam" && Voornaam.IsNullOrEmpty())
                {
                    return "Voornaam moet ingevuld zijn";
                }
                if (columnName == "Familienaam" && Familienaam.IsNullOrEmpty())
                {
                    return "Familienaam moet ingevuld zijn";
                }
                if (columnName == "Email" && Email.IsNullOrEmpty())
                {
                    return "Email moet ingevuld zijn";
                }
                if (columnName == "Straatnaam" && Straatnaam.IsNullOrEmpty())
                {
                    return "Straatnaam moet ingevuld zijn";
                }
                if (columnName == "Huisnummer" && Huisnummer.IsNullOrEmpty())
                {
                    return "Huisnummer moet ingevuld zijn";
                }
                if (columnName == "Postcode" && Postcode.IsNullOrEmpty())
                {
                    return "Postcode moet ingevuld zijn";
                }
                if (columnName == "Gemeente" && Gemeente.IsNullOrEmpty())
                {
                    return "Gemeente moet ingevuld zijn";
                }
                if (columnName == "Geboortedatum" && Geboortedatum == null)
                {
                    return "Geboortedatum moet ingevuld zijn";
                }
                if (columnName == "Geslacht" && Geslacht.IsNullOrEmpty())
                {
                    return "Geslacht moet ingevuld zijn";
                }
                if (columnName == "Email" && !ValidateEmail(Email))
                {
                    return "Email moet een geldig email adres zijn";
                }
                if (columnName == "Postcode" && !IsNumeriek(Postcode))
                {
                    return "Postcode moet een nummer zijn";
                }
                if (columnName == "Huisnummer" && !IsNumeriek(Huisnummer))
                {
                    return "Huisnummer moet een nummer zijn";
                }
                return "";
            }
        }

        public void AanpassenDeelnemer()
        {
            if (SelectedDeelnemer != null)
            {
                if (IsGeldig())
                {
                    _unitOfWork.DeelnemersRepo.Aanpassen(DeelnemerRecord);
                    int ok = _unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Deelnemer is niet aangepast");
                }
            }
            else
            {
                Foutmelding = "Selecteer een Deelnemer!";
            }
        }

        public void AanpassenMedisch()
        {
            if (SelectedMedisch != null)
            {
                if (IsGeldig())
                {
                    _unitOfWork.MedischeRepo.Aanpassen(MedischRecord);
                    int ok = _unitOfWork.Save();

                    FoutmeldingInstellenNaSave(ok, "Medisch record is niet aangepast");
                }
            }
            else
            {
                Foutmelding = "Selecteer een Medisch record!";
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenDeelnemer": return true;
                case "AanpassenDeelnemer": return true;
                case "VerwijderenDeelnemer": return true;
                case "ToevoegenMedisch": return true;
                case "AanpassenMedisch": return true;
                case "VerwijderenMedisch": return true;
                case "Zoeken": return true;
                case "ResettenDeelnemer": return true;
                case "ResettenMedisch": return true;
                case "OpenOpleidingView": return true;
                case "OpenReizenView": return true;
                case "OpenHomeView": return true;
                case "OpenInlogView": return true;
            }
            return true;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenDeelnemer": ToevoegenDeelnemer(); break;
                case "AanpassenDeelnemer": AanpassenDeelnemer(); break;
                case "VerwijderenDeelnemer": VerwijderenDeelnemer(); break;
                case "Zoeken": Zoeken(); break;
                case "ResettenDeelnemer": ResettenDeelnemer(); break;
                case "OpenPersoonView": OpenOpleidingView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
                case "ToevoegenMedisch": ToevoegenMedisch(); break;
                case "AanpassenMedisch": AanpassenMedisch(); break;
                case "VerwijderenMedisch": VerwijderenMedisch(); break;
                case "ResettenMedisch": ResettenMedisch(); break;
            }
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

        public void ResettenDeelnemer()
        {
            //if (this.IsGeldig())
            //{
            SelectedDeelnemer = null;
            DeelnemerRecordInstellen();
            Foutmelding = "";
            NotifyPropertyChanged(nameof(SelectedDeelnemer));
            //}
            //else
            //{
            //    Foutmelding = this.Error;
            //}
        }

        public void ResettenMedisch()
        {
            //if (this.IsGeldig())
            //{
            SelectedMedisch = null;
            MedischRecordInstellen();
            Foutmelding = "";
            NotifyPropertyChanged(nameof(SelectedMedisch));
            //}
            //else
            //{
            //    Foutmelding = this.Error;
            //}
        }

        public void ToevoegenDeelnemer()
        {
            //if (this.IsGeldig())
            //{
            //    //DeelnemerRecord.DeelnemerId = int.Parse(ID);
            //    if (IsGeldig())
            //    {
            _unitOfWork.DeelnemersRepo.Toevoegen(DeelnemerRecord);
            int ok = _unitOfWork.Save();
            Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen());
            NotifyPropertyChanged(nameof(Deelnemers));

            // FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
            //    }
            //}
        }

        public void ToevoegenMedisch()
        {
            //if (this.IsGeldig())
            //{
            MedischRecord.DeelnemerId = int.Parse(ID);
            //    if (IsGeldig())
            //    {
            _unitOfWork.MedischeRepo.Toevoegen(MedischRecord);
            int ok = _unitOfWork.Save();
            MedischLijst = new ObservableCollection<Medisch>(_unitOfWork.MedischeRepo.Ophalen());
            NotifyPropertyChanged(nameof(SelectedDeelnemer));

            // FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
            //    }
            //}
        }

        public bool ValidateEmail(string input)
        {
            bool email;
            if (input.Contains("@") && input.Contains("."))
            {
                return email = true;
            }
            else
            {
                return email = false;
            }
        }

        public void VerwijderenDeelnemer()
        {
            if (SelectedDeelnemer != null)
            {
                _unitOfWork.DeelnemersRepo.Verwijderen(SelectedDeelnemer.DeelnemerId);
                int ok = _unitOfWork.Save();
                Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen());
                NotifyPropertyChanged(nameof(Deelnemers));
                //     FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Deelnemer selecteren";
            }
        }

        public void VerwijderenMedisch()
        {
            if (SelectedMedisch != null)
            {
                _unitOfWork.MedischeRepo.Verwijderen(SelectedMedisch.DeelnemerId);
                int ok = _unitOfWork.Save();
                MedischLijst = new ObservableCollection<Medisch>(_unitOfWork.MedischeRepo.Ophalen());
                NotifyPropertyChanged(nameof(MedischLijst));
                //     FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Deelnemer selecteren";
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            //if (IsGeldig())
            //{
            RefreshDeelnemer();
            RefreshMedisch();
            if (Deelnemers == null || Deelnemers.Count <= 0)
            {
                Foutmelding = "Er zijn geen Deelnemer gevonden horende bij " + Voornaam + " " + Familienaam;
            }
            if (MedischLijst == null || MedischLijst.Count <= 0)
            {
                Foutmelding = "Er zijn geen medisch records gevonden horende bij " + Voornaam + " " + Familienaam;
            }
            //}
            //else
            //{
            Foutmelding = this.Error;
            //}
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

        private void MedischRecordInstellen()
        {
            if (SelectedMedisch != null)
            {
                MedischRecord = SelectedMedisch;
                NotifyPropertyChanged(nameof(SelectedMedisch));
            }
            else
            {
                MedischRecord = new Medisch();
            }
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshDeelnemer();
                ResettenDeelnemer();
                RefreshMedisch();
                ResettenMedisch();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        private void RefreshDeelnemer()
        {
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Voornaam.Contains(Voornaam)).ToList();
            ID = listDeelnemers[0].DeelnemerId.ToString();
            Deelnemers = new ObservableCollection<Deelnemer>(listDeelnemers);
            NotifyPropertyChanged(nameof(Deelnemers));
        }

        private void RefreshMedisch()
        {
            List<Medisch> listMedisch = (List<Medisch>)_unitOfWork.MedischeRepo.Ophalen(x => x.DeelnemerId == int.Parse(ID));

            MedischLijst = new ObservableCollection<Medisch>(listMedisch);
            NotifyPropertyChanged(nameof(MedischLijst));
        }
    }
}