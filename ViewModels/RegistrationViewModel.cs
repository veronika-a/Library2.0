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

namespace Library.ViewModels
{
   public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;

        private RelayCommand _signUp;
        public event EventHandler Closing;

        public bool Validated = false;

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
                       

                        using (MyAppContext appContext = new MyAppContext())
                        {
                            //logic of create new account
                            ReaderRepository readerRepository = new ReaderRepository(appContext);
                            
                            var reader = new Reader()
                            {
                                Email = this.email,
                                Password = this.password
                            };

                            readerRepository.Insert(reader);
                           // appContext.SaveChanges();

                            MessageBox.Show($"Welcome, {reader.Email} !", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                            CabinetReader cabinetReader = new CabinetReader(ref reader);
                            cabinetReader.Show();
                            
                            Closing?.Invoke(this, EventArgs.Empty);

                        }
                          
                    }));
            }
        }
        

        public RegistrationViewModel() { }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}