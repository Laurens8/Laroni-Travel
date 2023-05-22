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
        public string Foutmelding { get; set; }
        public override string this[string columnName] => throw new NotImplementedException();
        private Window _view;

        public HomeViewModel(Window view)
        {
            _view = view;
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
                var vm = new InlogViewModel(view);              
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
                var vm = new OpleidingViewModel(view);
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
                var vm = new PersoonViewModel(view);
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
                var vm = new ReizenViewModel(view);
                
                view.DataContext = vm;
                view.Show();
                _view.Close();
            }
        }
    }
}