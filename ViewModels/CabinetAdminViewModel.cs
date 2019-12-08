using Library.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModels
{
    
    public class CabinetAdminViewModel : INotifyPropertyChanged
    {
        private Reader reader;


        public CabinetAdminViewModel(Reader reader)
        {
            Reader = reader;

        }

        public Reader Reader { get => reader; set => reader = value; }
        public event EventHandler Closing;

        public bool Validated = false;

        

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
