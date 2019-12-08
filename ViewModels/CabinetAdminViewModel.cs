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

        private string email;
        private string name;
        private string phone;
        private string date;

        public CabinetAdminViewModel(Reader reader)
        {
            Reader = reader;

        }

        public Reader Reader { get => reader; set => reader = value; }
        public string Email { get => email; set => email = value; }
        public string Name { get => name; set => name = value; }
        public string Phone { get => phone; set => phone = value; }
        public string Date { get => date; set => date = value; }

        public event EventHandler Closing;

        public bool Validated = false;


       

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
