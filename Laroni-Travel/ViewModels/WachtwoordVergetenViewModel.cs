using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
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
                case "Opslaan": return true;
                case "OpenWachtwoordVergetenView": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Opslaan": Opslaan(); break;
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
                var view = new InlogView();
                var vm = new InlogViewModel(view, "");
                view.DataContext = vm;
                view.Show();
                _view.Close();            
        }

        public void Opslaan()
        {
            if (string.IsNullOrWhiteSpace(Wachtwoord))
            {
                Foutmelding = "Wachtwoord moet ingevuld zijn";
            }
            else if (string.IsNullOrWhiteSpace(Email))
            {
                Foutmelding = "Email moet ingevuld zijn";
            }
            else
            {
                if (WachtwoordCheck())
                {                    
                    if (EmailCheck())
                    {
                        Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen(x => x.Email == Email));
                        if (Deelnemers.Count != 0)
                        {
                            foreach (var item in Deelnemers)
                            {
                                item.Wachtwoord = CreateHash(Wachtwoord);
                                _unitOfWork.DeelnemersRepo.Aanpassen(item);
                                _unitOfWork.Save();
                            }
                            OpenInlogView();
                        }
                    }
                    else
                    {
                        Foutmelding = "Email is niet correct";
                    }
                }
            }                
        }

        private bool WachtwoordCheck()
        {
            bool check = false;
            if (Wachtwoord != null)
            {
                if (Wachtwoord.Length < 8)
                {
                    Foutmelding = "Wachtwoord moet minstens 8 tekens bevatten";
                }
                else if (Wachtwoord != WachtwoordBevestigen)
                {
                    Foutmelding = "Wachtwoorden komen niet overeen";
                }
                else
                {
                    check = true;
                }
            }            
            return check;
        }

        private bool EmailCheck()
        {
            bool check = false;
            List<Deelnemer> listDeelnemers = _unitOfWork.DeelnemersRepo.Ophalen(x => x.Email == Email).ToList();
            if (listDeelnemers.Count() != 0)
            {
                check= true;
            }
            else
            {
                check= false;
            }
            return check;
        }

        public void Dispose()
        {
            _unitOfWork?.Dispose();
        }

        //Voor wachtwoord hash en salt
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24;
        public const int ITERATIONS = 100000;

        public static string CreateHash(string input)
        {
            using (RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider())
            {
                byte[] salt = new byte[SALT_SIZE];
                provider.GetBytes(salt);

                using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(input, salt, ITERATIONS))
                {
                    byte[] hash = pbkdf2.GetBytes(HASH_SIZE);

                    byte[] hashWithSalt = new byte[SALT_SIZE + HASH_SIZE];
                    Buffer.BlockCopy(salt, 0, hashWithSalt, 0, SALT_SIZE);
                    Buffer.BlockCopy(hash, 0, hashWithSalt, SALT_SIZE, HASH_SIZE);

                    string hashString = Convert.ToBase64String(hashWithSalt);
                    return hashString;
                }
            }
        }
    }
}
