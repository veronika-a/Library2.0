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

    public class CatalogBookReaderViewModel : INotifyPropertyChanged
    {
        Reader thisreader;
        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;

        private RelayCommand _Delete;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        Book _book;

        ObservableCollection<Book> _books;
        public ObservableCollection<Book> Books
        {
            get { return _books; }
            set
            {
                _books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
        public CatalogBookReaderViewModel(Reader reader)
        {
            thisreader = reader;
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

        List<Book> GetBooks()
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                BookRepository bookRepository = new BookRepository(appContext);
                return (List<Book>)bookRepository.GetAll();
            }
        }

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                Books = new ObservableCollection<Book>(GetBooks().Where(i => i.Title.Contains(Search)));


            }
        }
        private RelayCommand _Order;
        public RelayCommand Order
        {
            get
            {

                return _Order ??
                    (_Order = new RelayCommand(obj =>
                    {
                        using (MyAppContext appContext = new MyAppContext())
                        {
                            ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);

                            var readerCard = new ReaderCard()
                            {
                                BookId = SelectedBook.Id,
                                ReaderId = thisreader.Id,
                                DateOrdered= DateTime.Now,
                                Status = false

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
        private RelayCommand _back;

        public RelayCommand Back
        {
            get
            {
                return _back ??
                    (_back = new RelayCommand(obj =>
                    {
                        BooksReader booksReader = new BooksReader(ref thisreader);
                        booksReader.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
    }
}
