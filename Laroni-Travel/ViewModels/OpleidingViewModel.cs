﻿using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
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
    public class OpleidingViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private ObservableCollection<Opleiding> _opleidingen;
        private Opleiding _opleidingSelected;
        private Opleiding _opleidingRecord;
        private ObservableCollection<Bestemming> _bestemming;
        private string _beschrijving;
        private string _straatnaam;
        private string _huisnummer;
        private string _postcode;
        private string _gemeente;
        private string _land;
        private DateTime _datum;
        public string ID { get; set; }
        public int Deelnemers { get; set; }
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
        public string Foutmelding { get; set; }
        public override string this[string columnName] => throw new NotImplementedException();

        public OpleidingViewModel()
        {
            Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen());
            Bestemming = new ObservableCollection<Bestemming>(_unitOfWork.BestemmingenRepo.Ophalen());
            Deelnemers = new ObservableCollection<DeelnemerOpleiding>(_unitOfWork.DeelnemerOpleidingenRepo.Ophalen()).Count();
        }     

        public void Dispose()
        {
            _unitOfWork.Dispose();
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

        public ObservableCollection<Bestemming> Bestemming
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
                NotifyPropertyChanged();
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

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "ToevoegenOpleiding": return true;
                case "AanpassenOpleiding": return true;
                case "VerwijderenOpleiding": return true;
                case "ResettenOpleiding": return true;
                case "OpenPersoonView": return true;
                case "OpenReizenView": return true;
                case "OpenHomeView": return true;
                case "OpenInlogView": return true;
                case "Zoeken": return true;
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
                case "OpenPersoonView": OpenPersoonView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
                case "Zoeken": Zoeken(); break;
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

        public void OpenPersoonView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var vm = new PersoonViewModel();
                var view = new PersoonView();
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

        public void Zoeken()
        {
            Foutmelding = "";

            RefreshOpleidingen();
            if (Opleidingen == null || Opleidingen.Count <= 0)
            {
                Foutmelding = "Er zijn geen Opleidingen gevonden";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        private void RefreshOpleidingen()
        {
            List<Opleiding> listOpleiding = (List<Opleiding>)_unitOfWork.OpleidingenRepo.Ophalen(x => x.OpleidingId == int.Parse(ID));

            Opleidingen = new ObservableCollection<Opleiding>(listOpleiding);
            NotifyPropertyChanged(nameof(Opleidingen));
        }

        private void OpleidingRecordInstellen()
        {
            OpleidingRecord = new Opleiding();
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
            //Foutmelding = this.Error;
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
            _unitOfWork.OpleidingenRepo.Toevoegen(OpleidingRecord);
            int ok = _unitOfWork.Save();
            FoutmeldingInstellenNaSave(ok, "Opleiding is niet toegevoegd");
        }
    }
}