using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
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

        public HomeViewModel(Window view, string email)
        {           
            InlogEmail = email;            
            _view = view;
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