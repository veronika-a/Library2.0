using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WcfServiceLibrary;

namespace Library.ViewModels
{
   public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;
        Service1 service1;

        private RelayCommand _signUp;
        public event EventHandler Closing;

        public bool Validated = false;

        public RegistrationViewModel()
        {
             service1 = new Service1();
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public RelayCommand SignUp
        {
            get
            {

                return _signUp ??
                    (_signUp = new RelayCommand(obj => {

                        var reader = new Reader()
                        {
                            Email = this.email,
                            Password = this.password
                        };
                         service1.registrationViewModel_signUp(reader);

                        CabinetReader cabinetReader = new CabinetReader(ref reader);
                        cabinetReader.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
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