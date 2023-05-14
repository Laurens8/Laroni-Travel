﻿using Laroni_Travel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Laroni_Travel.ViewModels
{
    public abstract class BaseViewmodel : IDataErrorInfo, INotifyPropertyChanged, ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract string this[string columnName] { get; }

        public string Error
        {
            get
            {
                string foutmeldingen = "";

                foreach (var item in this.GetType().GetProperties())
                {
                    string fout = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout + Environment.NewLine;
                    }
                }
                return foutmeldingen;
            }
        }

        public bool IsGeldig()
        {
            return string.IsNullOrWhiteSpace(Error);
        }

        private void ReizenRecordInstellen()
        {
            if (SelectedGroepsreis != null)
            {
                ReisRecord = SelectedGroepsreis;
                NotifyPropertyChanged(nameof(SelectedGroepsreis));
            }
            else
            {
                ReisRecord = new Groepsreis();
            }
        }
    }
}