using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModels
{
    public class CabinetReaderViewModel : INotifyPropertyChanged
    {
        private Reader reader;
        public CabinetReaderViewModel(Reader reader)
        {
            Reader = reader;
        }

        public Reader Reader { get => reader; set => reader = value; }

        private RelayCommand _signUp;
        public event EventHandler Closing;

        public bool Validated = false;

        

        //public RelayCommand PasswordChangedCommand
        //{
        //    get
        //    {
        //        return _addPaswordChangedCommand ??
        //            (_addPaswordChangedCommand = new RelayCommand(obj =>
        //            {
        //                PasswordBox passwordBox = obj as PasswordBox;
        //                Password = passwordBox.Password;
        //            }
        //            ));
        //    }
        //}



        //public RelayCommand ToLoginPageCommand
        //{
        //    get
        //    {
        //        return _toLoginPageCommand ??
        //            (_toLoginPageCommand = new RelayCommand(obj =>
        //            {
        //                ClosingRequest?.Invoke(this, EventArgs.Empty);
        //            }));


        //    }
        //}
       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
