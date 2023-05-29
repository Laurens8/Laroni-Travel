using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class HomeViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
        public override string this[string columnName] => throw new NotImplementedException();
        private Window _view;
        private string _inlogEmail;
        private string _email;
        private string _foutmelding;
        public ObservableCollection<OpleidingBestemming> Bestemmingen { get; set; }
        public ObservableCollection<DeelnemerOpleiding> DeelnemersOpleiding { get; set; }
        public ObservableCollection<Opleiding> Opleidingen { get; set; }
        public ObservableCollection<Deelnemer> AantalDeelnemers { get; set; }
        public ObservableCollection<Groepsreis> AantalReizen { get; set; }

        public HomeViewModel(Window view, string email)
        {
            InlogEmail = email;
            _view = view;

            AantalReizen = new ObservableCollection<Groepsreis>(_unitOfWork.GroepsreisenRepo.Ophalen(r => r.DeelnemerGroepsreizen));
            Opleidingen = new ObservableCollection<Opleiding>(_unitOfWork.OpleidingenRepo.Ophalen().Where(o => o.Datum.Month == DateTime.Now.Month + 1));
            Bestemmingen = new ObservableCollection<OpleidingBestemming>(_unitOfWork.OpleidingBestemmingenRepo.Ophalen());
            DeelnemersOpleiding = new ObservableCollection<DeelnemerOpleiding>(_unitOfWork.DeelnemerOpleidingenRepo.Ophalen());
            AantalDeelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen(d => d.DeelnemerGroepsreizen));
            Opleidingen.ToString();
            AantalDeelnemers.ToString();
            AantalReizen.ToString();
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

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
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

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenPersoonView": return true;
                case "OpenReizenView": return true;
                case "OpenOpleidingView": return true;
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
                case "OpenPersoonView": OpenPersoonView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenOpleidingView": OpenOpleidingView(); break;
                case "OpenInlogView": OpenInlogView(); break;
            }
        }

        public void OpenInlogView()
        {
            Foutmelding = "";
            if (Foutmelding == "")
            {
                var view = new InlogView();
                var vm = new InlogViewModel(view, InlogEmail);              
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

        public void OpenPersoonView()
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
    }
}