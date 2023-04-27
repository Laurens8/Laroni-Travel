using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
//using Laroni_Travel.Models.Partials;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Laroni_Travel.ViewModels
{
    public class PersoonViewModel : BaseViewmodel, IDisposable
    {
        private IUnitOfWork _unitOfWork = new UnitOfWork(new Laronu_TravelContext());

        public ObservableCollection<Deelnemer> Deelnemers { get; set; }
        public Deelnemer DeelnemerRecord { get; set; }
        public string Foutmelding { get; set; }
        public string ID { get; set; }
        private Deelnemer _selectedDeelnemer;

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

        public override string this[string columnName]
        {
            get
            {               
                return "";
            }
        }

        public PersoonViewModel() 
        {
            Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen(x => x.DeelnemerId));
            DeelnemerRecordInstellen();
        }

        public void Aanpassen()
        {
            if (SelectedDeelnemer != null)
            {
                //if (DeelnemerRecord.IsGeldig())
                //{
                //    _unitOfWork.DeelnemersRepo.ToevoegenOfAanpassen(DeelnemerRecord);
                //    int ok = _unitOfWork.Save();

                //    FoutmeldingInstellenNaSave(ok, "Deelnemer is niet aangepast");
                //}
            }
            else
            {
                Foutmelding = "Selecteer een Deelnemer!";
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
                    Foutmelding = "Er zijn geen Deelnemer gevonden horende bij ID " + ID;
                }
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        public void Verwijderen()
        {
            if (SelectedDeelnemer != null)
            {
                _unitOfWork.DeelnemersRepo.Verwijderen(SelectedDeelnemer.DeelnemerId);
                int ok = _unitOfWork.Save();
                FoutmeldingInstellenNaSave(ok, "Deelnemer is niet verwijderd");
            }
            else
            {
                Foutmelding = "Eerst Deelnemer selecteren";
            }
        }

        public void Toevoegen()
        {
            if (this.IsGeldig())
            {
                DeelnemerRecord.DeelnemerId = int.Parse(ID);
                //if (DeelnemerRecord.IsGeldig())
                //{
                //    _unitOfWork.DeelnemersRepo.Toevoegen(DeelnemerRecord);
                //    int ok = _unitOfWork.Save();

                //    FoutmeldingInstellenNaSave(ok, "Deelnemer is niet toegevoegd");
                //}
            }
        }

        private void DeelnemerRecordInstellen()
        {
            if (SelectedDeelnemer != null)
            {
                DeelnemerRecord = SelectedDeelnemer;
            }
            else
            {
                DeelnemerRecord = new Deelnemer();
            }
        }

        public void Resetten()
        {
            if (this.IsGeldig())
            {
                SelectedDeelnemer = null;
                DeelnemerRecordInstellen();
                Foutmelding = "";
            }
            else
            {
                Foutmelding = this.Error;
            }
        }

        private void FoutmeldingInstellenNaSave(int ok, string melding)
        {
            if (ok > 0)
            {
                RefreshDeelnemer();
                Resetten();
            }
            else
            {
                Foutmelding = melding;
            }
        }

        private void RefreshDeelnemer()
        {
            int i = int.Parse(ID);
            List<Deelnemer> listOrderlijnen = _unitOfWork.DeelnemersRepo.Ophalen(x => x.DeelnemerId == i).ToList();

            Deelnemers = new ObservableCollection<Deelnemer>(listOrderlijnen);
        }

        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Aanmelden": return true;         
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Aanmelden": Zoeken(); break;               
            }
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }
    }
}
