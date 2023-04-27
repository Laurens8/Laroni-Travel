using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class HomeViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public override string this[string columnName] => throw new NotImplementedException();
        public string Foutmelding { get; set; }

        public void OpenPersoonView()
        {
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
            if (Foutmelding == "")
            {
                var vm = new ReizenViewModel();
                var view = new ReizenView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public void OpenOpleidingView()
        {
            if (Foutmelding == "")
            {
                var vm = new OpleidingViewModel();
                var view = new OpleidingView();
                view.DataContext = vm;
                view.Show();
            }
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenPersoonView": return true;
                case "OpenReizenView": return true;
                case "OpenOpleidingView": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenPersoonView": OpenPersoonView(); break;
                case "OpenReizenView": OpenReizenView(); break;
                case "OpenOpleidingView": OpenOpleidingView(); break;
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
