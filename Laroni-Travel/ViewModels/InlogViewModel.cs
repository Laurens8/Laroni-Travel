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
    public class InlogViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laroni_TravelContext());

        public ObservableCollection<Deelnemer> Deelnemers { get; set; }        
        private Window _view;
        private string _email;
        private string _foutmelding;

        public InlogViewModel(Window view, string email)
        {
            Email = email;
            _view= view;
            RefreshDeelnemer();
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

        public override string this[string columnName]
        {
            get { return columnName; }
        }

        public void OpenHomeView()
        {
            Zoeken();
            if (Foutmelding == "")
            {          
                var view = new HomeView();
                var vm = new HomeViewModel(view, Email);
                view.DataContext = vm;
                view.Show();
                App.Current.MainWindow.Close();
            }
        }

        public void Zoeken()
        {
            Foutmelding = "";
            if (true)
            {
                RefreshDeelnemer();
                if (Deelnemers == null || Deelnemers.Count <= 0)
                {
                    Foutmelding = "Er zijn geen Deelnemer gevonden met de emailadress " + Email;
                }
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        private void RefreshDeelnemer()
        {
            string email = Email;
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Email == Email).ToList();
            Deelnemers = new ObservableCollection<Deelnemer>(listDeelnemers);
        }

        public void OpenWachtwoordVergetenView()
        {                      
            var view = new WachtwoordVergetenView();
            var vm = new WachtwoordVergetenViewModel(view);
            view.DataContext = vm;
            view.Show();
            _view.Close();
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenHomeView": return true;
                case "OpenWachtwoordVergetenView": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenWachtwoordVergetenView": OpenWachtwoordVergetenView(); break;
            }            
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
