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
using WcfServiceLibrary;

namespace Library.ViewModels
{

    public class SingInViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;
        Service1 service1;
        private RelayCommand _signIn;
        public event EventHandler Closing;

        public bool Validated = false;

        public SingInViewModel()
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

        public RelayCommand SignIn
        {
            get
            {

                return _signIn ??
                    (_signIn = new RelayCommand(obj =>
                    {
                        var reader = service1.singInViewModel_signIn(email, password);

                        if (reader != null)
                        {
                            if (reader.Email != "admin")
                            {
                                MessageBox.Show($"Welcome, {reader.Email} !", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                                CabinetReader cabinetReader = new CabinetReader(ref reader);
                                cabinetReader.Show();
                                Closing?.Invoke(this, EventArgs.Empty);
                            }
                            else
                            {
                                CabinetAdmin cabinetAdmin = new CabinetAdmin(ref reader);
                                cabinetAdmin.Show();
                                Closing?.Invoke(this, EventArgs.Empty);
                            }
                        }
                    }));
            }
        }

        public object Server1 { get; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
