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

    public class CatalogBooksReaderViewModel : INotifyPropertyChanged
    {
        Reader thisreader;
        public event EventHandler Closing;
        Service1 service1;
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
        public CatalogBooksReaderViewModel(Reader reader)
        {
            thisreader = reader;
             service1 = new Service1();
            Books = new ObservableCollection<Book>(service1.catalogBooksReaderViewModel_getBooks());
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

        

        //CabinetAdminModel

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                Books = new ObservableCollection<Book>(service1.catalogBooksReaderViewModel_getBooks().Where(i => i.Title.Contains(Search)));


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
                        var readerCard = new ReaderCard()
                        {
                            BookId = SelectedBook.Id,
                            ReaderId = thisreader.Id,
                            DateOrdered = DateTime.Now,
                            Status = false

                        };
                        service1.catalogBooksReaderViewModel_order(readerCard);

                        BooksReader booksReader = new BooksReader(ref thisreader);
                        booksReader.Show();
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
                        BooksReader booksReader = new BooksReader(ref thisreader);
                        booksReader.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
    }
}
