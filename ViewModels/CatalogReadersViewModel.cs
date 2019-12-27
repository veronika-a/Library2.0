using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfServiceLibrary;

namespace Library.ViewModels
{
    public class CatalogReadersViewModel : INotifyPropertyChanged
    {
        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;
        Service1 service1;
        Reader thisreader;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        //Reader _reader;

        ObservableCollection<Reader> _readers;
        public ObservableCollection<Reader> Readers
        {
            get { return _readers; }
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }
        public CatalogReadersViewModel(Reader reader)
        {
            thisreader = reader;
             service1 = new Service1();
            Readers = new ObservableCollection<Reader>(service1.catalogReadersViewModel_getReaders());
        }

      

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                Readers = new ObservableCollection<Reader>(service1.catalogReadersViewModel_getReaders().Where(i => i.Email.Contains(Search)));                                               
            }
        }

        private RelayCommand _back;

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(obj =>
                    {
                        CabinetAdmin cabinet = new CabinetAdmin(ref thisreader);
                        cabinet.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }

        private RelayCommand _AddReader;

        public RelayCommand AddReader
        {
            get
            {
                return _AddReader ??
                    (_AddReader = new RelayCommand(obj =>
                    {
                        NewUser newUser = new NewUser(ref thisreader);
                        newUser.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }

        private RelayCommand _EditReader;

        public RelayCommand EditReader
        {
            get
            {
                return _EditReader ??
                    (_EditReader = new RelayCommand(obj =>
                    {
                    //    NewUser newUser = new NewUser(ref thisreader);
                    //    newUser.Show();
                    //    Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }

        //            <Button Content = "Добавить" Margin="0 20 0 0" Style="{StaticResource BaseButton}" Command="{Binding AddReader}"/>
        //            <Button Content = "Изменить" Margin="0 20 0 0" Style="{StaticResource BaseButton}" Command="{Binding EditReader}"/>
        //            <Button Content = "Удалить" Margin="0 20 0 0" Style="{StaticResource BaseButton}" Command="{Binding DeleteReader}"/>
        //            <Button Content = "Назад"  Margin="0 40 0 0" Style="{StaticResource BaseButton}" Command="{Binding Back}"/>

    }
}
