using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.ViewModels
{
    public class ReizenViewModel : BaseViewmodel, IDisposable
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public string Foutmelding { get; set; }

        public override string this[string columnName] => throw new NotImplementedException();

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenPersoonView": return true;
                case "OpenOpleidingView": return true;
                case "OpenHomeView": return true;
                case "OpenInlogView": return true;
            }
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenPersoonView": OpenPersoonView(); break;
                case "OpenReizenView": OpenOpleidingView(); break;
                case "OpenHomeView": OpenHomeView(); break;
                case "OpenInlogView": OpenInlogView(); break;
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
    }
}