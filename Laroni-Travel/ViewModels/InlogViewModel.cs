using dal.Data.UnitOfWork;
using Laroni_Travel.Data;
using Laroni_Travel.Models;
using Laroni_Travel.View;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Security.Policy;
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
        private string _wachtwoord;

        public InlogViewModel(Window view, string email)
        {
            _view= view;
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
            RefreshDeelnemer();
            if (ValidateWachtwoord())
            {
                if (Deelnemers[0].Admin == true)
                {
                    var view = new HomeView();
                    var vm = new HomeViewModel(view, Email);
                    view.DataContext = vm;
                    view.Show();
                    _view.Close();
                }
                else
                {
                    Foutmelding = "Deze gebruiker heeft geen admin rechten";
                }
            }
            else
            {
                Foutmelding = "Het wachtwoord of emailadres is niet correct";
            }
        }

        private void RefreshDeelnemer()
        {
            if (Email != string.Empty)
            {
                Deelnemers = new ObservableCollection<Deelnemer>(_unitOfWork.DeelnemersRepo.Ophalen(x => x.Email == Email));
            }
        }

        private bool ValidateWachtwoord()
        {
            if (string.IsNullOrEmpty(Wachtwoord) || Deelnemers.Count == 0)
            {
                return false;
            }
            bool isValid = ValidatePassword(Wachtwoord, Deelnemers[0].Wachtwoord);
            return isValid;
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

        //Voor wachtwoord hash en salt
        public const int SALT_SIZE = 24;
        public const int HASH_SIZE = 24;
        public const int ITERATIONS = 100000;

        public bool ValidatePassword(string inputPassword, string storedHashedPassword)
        {
            if (storedHashedPassword != null)
            {
                byte[] storedHashBytes = Convert.FromBase64String(storedHashedPassword);

                byte[] salt = new byte[SALT_SIZE];
                Array.Copy(storedHashBytes, 0, salt, 0, SALT_SIZE);

                Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, ITERATIONS);
                byte[] inputHashBytes = pbkdf2.GetBytes(HASH_SIZE);

                byte[] inputHashWithSaltBytes = new byte[SALT_SIZE + HASH_SIZE];
                Array.Copy(salt, 0, inputHashWithSaltBytes, 0, SALT_SIZE);
                Array.Copy(inputHashBytes, 0, inputHashWithSaltBytes, SALT_SIZE, HASH_SIZE);

                bool passwordsMatch = storedHashBytes.SequenceEqual(inputHashWithSaltBytes);

                string hashString = Convert.ToBase64String(inputHashWithSaltBytes);
                byte[] sredHashBytes = Convert.FromBase64String(hashString);

                return passwordsMatch;
            }
            else
            {
                Foutmelding = "Wachtwoord moet inguvuld zijn";
            }
            return false;
        }
    }
}
