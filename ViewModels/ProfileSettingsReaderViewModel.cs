﻿using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WcfServiceLibrary;

namespace Library.ViewModels
{
   
    public class ProfileSettingsReaderViewModel : INotifyPropertyChanged
    {
        private Reader reader;

        private string firstName;
        private string secondName;
        private string phone;
        private DateTime? date;

        Service1 service1;

        public ProfileSettingsReaderViewModel(Reader reader)
        {
            Reader = reader;
            service1 = new Service1();
            firstName = this.reader.FirstName;
            secondName = this.reader.SecondName;
            phone = this.reader.Phone;
            date = this.reader.Date;
        }

        public Reader Reader { get => reader; set => reader = value; }

        public string FirstName
        {
            get { return firstName; }
            set
            {
                firstName = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        public string SecondName
        {
            get { return secondName; }
            set
            {
                secondName = value;
                OnPropertyChanged(nameof(SecondName));
            }
        }
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        public DateTime? Date
        {
            get { return date; }
            set
            {
                date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        public event EventHandler Closing;

        public bool Validated = false;

        private RelayCommand _SaveCommand;
        public RelayCommand SaveCommand
        {
            get
            {
                return _SaveCommand ??
                    (_SaveCommand = new RelayCommand(obj =>
                    {
                        reader.FirstName = FirstName;
                        reader.SecondName = SecondName;
                        reader.Phone = Phone;
                        reader.Date = Date;
                        service1.profileSettingsReaderViewModel_save(reader);
                    }));
            }
        }
        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
