using Library.Models;
using Library.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using WcfServiceLibrary;

namespace Library.ViewModels
{

    public class CabinetAdminViewModel : INotifyPropertyChanged
    {
        private Reader reader;
        Service1 service1;

        public CabinetAdminViewModel(Reader reader)
        {
             service1 = new Service1();
            Reader = reader;
            ReaderCards = new ObservableCollection<ReaderCard>(service1.cabinetAdminModel_GetReaderCards());
        }

        public Reader Reader { get => reader; set => reader = value; }
        public event EventHandler Closing;

        public bool Validated = false;


        ObservableCollection<ReaderCard> _readerCards;
        public ObservableCollection<ReaderCard> ReaderCards
        {
            get { return _readerCards; }
            set
            {
                _readerCards = value;
                OnPropertyChanged(nameof(ReaderCards));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        ReaderCard selectedReaderCard;
        public ReaderCard SelectedReaderCard
        {
            get { return selectedReaderCard; }
            set
            {
                selectedReaderCard = value;
                OnPropertyChanged(nameof(SelectedReaderCard));
            }
        }
        private RelayCommand _DoOrder;

        public RelayCommand DoOrder
        {
            get
            {
                return _DoOrder ??
                    (_DoOrder = new RelayCommand(obj =>
                    {
                        service1.cabinetAdminModel_doOrder(SelectedReaderCard);
                        CabinetAdmin cabinet = new CabinetAdmin(ref reader);
                        cabinet.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        private RelayCommand _orders;

        public RelayCommand Orders
        {
            get
            {
                return _orders ??
                    (_orders = new RelayCommand(obj =>
                    {
                        Orders orders = new Orders(ref reader);
                        orders.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
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
                        MainWindow main = new MainWindow();
                        main.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        private RelayCommand _CalalogReaders;

        public RelayCommand CalalogReaders
        {
            get
            {
                return _CalalogReaders ??
                    (_CalalogReaders = new RelayCommand(obj =>
                    {
                        CatalogReaders catalog = new CatalogReaders(ref reader);
                        catalog.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        private RelayCommand _CalalogBookAdmin;

        public RelayCommand CalalogBookAdmin
        {
            get
            {
                return _CalalogBookAdmin ??
                    (_CalalogBookAdmin = new RelayCommand(obj =>
                    {
                         CatalogBooksAdmin catalog = new CatalogBooksAdmin(ref reader);
                        catalog.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
    }
}
