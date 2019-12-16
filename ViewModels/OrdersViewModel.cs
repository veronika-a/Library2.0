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

namespace Library.ViewModels
{
    public class OrdersViewModel : INotifyPropertyChanged
    {
        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;
        private RelayCommand _Give;
        private RelayCommand _Get;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        Book _book;
        Reader _reader;

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

        public OrdersViewModel()
        {
            Readers = new ObservableCollection<Reader>(GetReaders());
            Books = new ObservableCollection<Book>(GetBooks());
        }
        Book selectedBook;
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        Reader selectedReader;
        public Reader SelectedReader
        {
            get { return selectedReader; }
            set
            {
                selectedReader = value;
                OnPropertyChanged(nameof(SelectedReader));
            }
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
        List<Book> GetBooks()
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                BookRepository bookRepository = new BookRepository(appContext);
                return (List<Book>)bookRepository.GetAll();
            }
        }
        List<Reader> GetReaders()
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderRepository readerRepository = new ReaderRepository(appContext);
                return (List<Reader>)readerRepository.GetAll();
            }
        }

        private string _doOrder;
        public string DoOrder
        {
            get { return _doOrder; }
            set
            {
                _doOrder = value;
                OnPropertyChanged(nameof(DoOrder));


                using (MyAppContext appContext = new MyAppContext())
                {
                    ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                    selectedReaderCard.Status = true;
                    selectedReaderCard.DateTook = DateTime.Now;
                    readerCardRepository.Update(selectedReaderCard);
                }

            }
        }
        public RelayCommand Give
        {
            get
            {

                return _Give ??
                    (_Give = new RelayCommand(obj =>
                    {
                        using (MyAppContext appContext = new MyAppContext())
                        {
                            ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);

                            var readerCard = new ReaderCard()
                            {
                                BookId = SelectedBook.Id,
                                ReaderId = SelectedReader.Id,
                                DateTook = DateTime.Now,
                                Status = true

                            };

                            readerCardRepository.Insert(readerCard);
                            MessageBox.Show($" {readerCard} !", "New ", MessageBoxButton.OK, MessageBoxImage.Information);


                            Orders orders = new Orders();
                            orders.Show();
                            Closing?.Invoke(this, EventArgs.Empty);
                        }
                    }));
            }
        }

    }
}
