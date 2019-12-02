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

    public class SingInViewModel : INotifyPropertyChanged
    {
        private string email;
        private string password;

        private RelayCommand _signIn;
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
        public RelayCommand SignIn
        {
            get
            {

                return _signIn ??
                    (_signIn = new RelayCommand(obj =>
                    {
                        //if (!Validated)
                        //{
                        //    MessageBox.Show("Form Is Invalid or has empty fields", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                        //    return;
                        //}

                        using (MyAppContext appContext = new MyAppContext())
                        {
                            //logic of create new account
                            ReaderRepository readerRepository = new ReaderRepository(appContext);
                            var reader = readerRepository.GetAll(u => u.Email == email || u.Password == password).FirstOrDefault();

                            if (reader != null)
                            {
                                // MessageBox.Show("User already exists");
                                // MessageBox.Show("User already exists");
                                // appContext.SaveChanges();

                                MessageBox.Show($"Welcome, {reader.Email} !", "Welcome", MessageBoxButton.OK, MessageBoxImage.Information);

                                CabinetReader cabinetReader = new CabinetReader( ref reader);
                                cabinetReader.Show();
                                Closing?.Invoke(this, EventArgs.Empty);

                            }



                        }

                    }));
            }
        }
        //public string this[string columnName]
        //{
        //    get
        //    {
        //        string message = string.Empty;

        //        switch (columnName)
        //        {
        //            case "Email":
        //                if (!DataValidation.ValidateString(Email))
        //                    message = "NAME should be only letters and 3-15 symbols";
        //                break;


        //            case "Password":
        //                if (!DataValidation.ValidatePassword(Password))
        //                    message = "Password should be 3-15 symbols, " +
        //                        "uppercase and lowercase letter and number";
        //                break;

        //        }
        //        Validated = DataValidation.ValidateString(Email) && DataValidation.ValidatePassword(Password);
        //        return message;
        //    }
        //}
        //public string Error
        //{
        //    get { return this[string.Empty]; }
        //}



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
