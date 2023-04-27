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
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public class InlogViewModel : BaseViewmodel, IDisposable, ICommand
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public ObservableCollection<Deelnemer> Deelnemers { get; set; }
        public string Foutmelding { get; set; }

        private string _email = "";

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
            get
            {               
                return "";
            }
        }

        public void OpenHomeView()
        {
            Zoeken();
            if (Foutmelding == "")
            {
                var vm = new HomeViewModel();
                var view = new HomeView();
                view.DataContext = vm;
                view.Show();
            }           
        }

        public void Zoeken()
        {
            Foutmelding = "";
            if (IsGeldig())
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

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenHomeView": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "OpenHomeView": OpenHomeView(); break;                   
            }            
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
