using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class WachtwoordVergetenViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());
        public ObservableCollection<Deelnemer> Deelnemers { get; set; }
        private Window _view;
        private string _email;
        private string _foutmelding;
        private string _wachtwoord;
        private string _wachtwoordBevestigen;

        public WachtwoordVergetenViewModel(Window view)
        {
            _view = view;
        }

        public override string this[string columnName]
        {
            get { return columnName; }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenInlogView": return true;
                case "OpenWachtwoordVergetenView": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenInlogView": OpenInlogView(); break;
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

        public string Foutmelding
        {
            get { return _foutmelding; }
            set 
            {
                _foutmelding = value;
                NotifyPropertyChanged();
            }
        }

        public string Wachtwoord
        {
            get { return _wachtwoord; }
            set
            { 
                _wachtwoord = value;
                NotifyPropertyChanged();
            }
        }

        public string WachtwoordBevestigen
        {
            get { return _wachtwoordBevestigen; }
            set
            {
                _wachtwoordBevestigen = value;
                NotifyPropertyChanged();
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

        public void Opslaan()
        {
            Foutmelding = "";
            if (Wachtwoord != WachtwoordBevestigen)
            {
                Foutmelding = "Wachtwoorden komen niet overeen";
            }
            if (Foutmelding == "")
            {
                RefreshDeelnemer();
                foreach (var item in Deelnemers)
                {
                    item.Wachtwoord = Wachtwoord;
                    _unitOfWork.DeelnemersRepo.Aanpassen(item);
                    _unitOfWork.Save();
                    Wachtwoord = "";
                    WachtwoordBevestigen = "";
                    OpenInlogView();
                }
            }
        }

        private void RefreshDeelnemer()
        {
            string email = Email;
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Email == Email).ToList();
            foreach (var item in listDeelnemers)
            {
                if (item.Email == Email)
                {
                    Deelnemers = new ObservableCollection<Deelnemer>(listDeelnemers);
                }
                else
                {
                    Foutmelding = "Email of wachtwoord is niet correct";
                }
            }           
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
