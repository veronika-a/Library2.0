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

namespace Library.ViewModels
{
   
    public class BooksReaderViewModel : INotifyPropertyChanged
    {
        private Reader thisreader;

        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;
        private RelayCommand _Edit;
        private RelayCommand _Delete;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        ReaderCard _readerCard;

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
        Book _bookCard;

        ObservableCollection<Book> _bookCards;
        public ObservableCollection<Book> BookCards
        {
            get { return _bookCards; }
            set
            {
                _bookCards = value;
                OnPropertyChanged(nameof(BookCards));
            }
        }


        public BooksReaderViewModel(Reader reader)
        {
            thisreader = reader;
            ReaderCards = new ObservableCollection<ReaderCard>(GetReaderCards());
           

        }
        ReaderCard selectedReaderCards;
        public ReaderCard SelectedReaderCards
        {
            get { return selectedReaderCards; }
            set
            {
                selectedReaderCards = value;
                OnPropertyChanged(nameof(SelectedReaderCards));
            }
        }

        List<ReaderCard> GetReaderCards()
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
              var  thisreaderCards = readerCardRepository.GetAll(u => u.ReaderId ==thisreader.Id);
                BookRepository bookRepository = new BookRepository(appContext);
                 BookCards = new ObservableCollection<Book>();
                foreach (var thisreaderCard in thisreaderCards)
                {
                    BookCards.Add(bookRepository.GetById(thisreaderCard.BookId));
                }
                return thisreaderCards;
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

               
                using (MyAppContext appContext = new MyAppContext())
                {
                    BookRepository bookRepository = new BookRepository(appContext);
                    BookCards = new ObservableCollection<Book>();
                    foreach (var thisreaderCard in ReaderCards)
                    {
                        BookCards.Add(bookRepository.GetAll(u => u.Title.Contains(Search) & u.Id == thisreaderCard.BookId).FirstOrDefault());
                    }
                  // BookCards = new ObservableCollection<Book>(bookRepository.GetAll(u => u.Title.Contains(Search)));
                   
                }

            }
        }
        private RelayCommand _newOrder;

        public RelayCommand NewOrder
        {
            get
            {
                return _newOrder ??
                    (_newOrder = new RelayCommand(obj =>
                    {
                        //CabinetReader cabinetReader = new CabinetReader(ref thisreader);
                        //cabinetReader.Show();
                        //Closing?.Invoke(this, EventArgs.Empty);
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
                        CabinetReader cabinetReader = new CabinetReader(ref thisreader);
                        cabinetReader.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
        //public RelayCommand Edit
        //{
        //    get
        //    {

        //        return _Edit ??
        //            (_Edit = new RelayCommand(obj =>
        //            {
        //                using (MyAppContext appContext = new MyAppContext())
        //                {
        //                    BookRepository bookRepository = new BookRepository(appContext);
        //                    var book = selectedBook;
        //                    EditBook editBook = new EditBook(ref book);
        //                    editBook.Show();
        //                    Closing?.Invoke(this, EventArgs.Empty);
        //                }
        //            }));
        //    }
        //}
        //public RelayCommand Delete
        //{
        //    get
        //    {

        //        return _Delete ??
        //            (_Delete = new RelayCommand(obj =>
        //            {
        //                using (MyAppContext appContext = new MyAppContext())
        //                {
        //                    BookRepository bookRepository = new BookRepository(appContext);
        //                    var book = selectedBook;
        //                    bookRepository.Delete(book);
        //                    CatalogBooksAdmin catalog = new CatalogBooksAdmin();
        //                    catalog.Show();
        //                    Closing?.Invoke(this, EventArgs.Empty);
        //                }
        //            }));
        //    }
        //}

    }
}
