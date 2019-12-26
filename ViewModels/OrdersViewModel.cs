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
using System.Windows;
using WcfServiceLibrary;

namespace Library.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        public event EventHandler Closing;
        private RelayCommand _Give;
        private RelayCommand _Get;
        private RelayCommand _DoOrder;

        Book selectedBook;
        Reader selectedReader;
        ReaderCard selectedReaderCard;
        Service1 service1;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        //Book _book;
        //Reader _reader;
        Reader thisreader;
        ObservableCollection<ReaderCard> _readerCards;
        ObservableCollection<Book> _books;
        ObservableCollection<Reader> _readers;

        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        public ObservableCollection<Reader> Readers
        {
            get { return _readers; }
            set
            {
                _readers = value;
                OnPropertyChanged(nameof(Readers));
            }
        }
        public ObservableCollection<ReaderCard> ReaderCards
        {
            get { return _readerCards; }
            set
            {
                _readerCards = value;
                OnPropertyChanged(nameof(ReaderCards));
            }
        }

        public OrdersViewModel( Reader reader)
        {
            thisreader = reader;
             service1 = new Service1();
            Readers = new ObservableCollection<Reader>(service1.ordersViewModel_getReaders());
            Books = new ObservableCollection<Book>(service1.ordersViewModel_getBooks());
            ReaderCards = new ObservableCollection<ReaderCard>(service1.ordersViewModel_getReaderCards());
        }

        
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        public Reader SelectedReader
        {
            get { return selectedReader; }
            set
            {
                selectedReader = value;
                OnPropertyChanged(nameof(SelectedReader));
            }
        }
        public ReaderCard SelectedReaderCard
        {
            get { return selectedReaderCard; }
            set
            {
                selectedReaderCard = value;
                OnPropertyChanged(nameof(SelectedReaderCard));
            }
        }
        
        public RelayCommand DoOrder
        {
            get
            {
                return _DoOrder ??
                    (_DoOrder = new RelayCommand(obj =>
                    {
                        service1.ordersViewModel_doOrder(SelectedReaderCard);
                        Orders orders = new Orders(ref thisreader);
                        orders.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        public RelayCommand Give
        {
            get
            {

                return _Give ??
                    (_Give = new RelayCommand(obj =>
                    {
                        var readerCard = new ReaderCard()
                        {
                            BookId = SelectedBook.Id,
                            ReaderId = SelectedReader.Id,
                            DateTook = DateTime.Now,
                            Status = true

                        };
                        service1.ordersViewModel_give(readerCard);
                        Orders orders = new Orders(ref thisreader);
                        orders.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        public RelayCommand Get
        {
            get
            {

                return _Get ??
                    (_Get = new RelayCommand(obj =>
                    {
                        service1.ordersViewModel_get(SelectedReaderCard);
                        Orders orders = new Orders(ref thisreader);
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
                        CabinetAdmin cabinet = new CabinetAdmin(ref thisreader);
                        cabinet.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }


    }
}
