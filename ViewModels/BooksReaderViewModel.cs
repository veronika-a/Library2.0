using Library.Models;
using Library.Views;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Library.ViewModels
{

    public class BooksReaderViewModel : INotifyPropertyChanged
    {
        private Reader thisreader;
        private string _search;
        private string _take;
        ReaderCard _readerCard;
        Book _bookCard;
        Book selectedBookCard;
        BooksReaderModel booksReaderModel;

        public BooksReaderViewModel(Reader reader)
        {
            thisreader = reader;
            booksReaderModel = new BooksReaderModel();
            BookCards = new ObservableCollection<Book>(booksReaderModel.GetBookCards(thisreader, BookCards));
           
        }

        public event EventHandler Closing;
        private RelayCommand _back;
        private RelayCommand _newOrder;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       
        ObservableCollection<ReaderCard> _readerCards;
        ObservableCollection<Book> _bookCards;

        public ObservableCollection<ReaderCard> ReaderCards
        {
            get { return _readerCards; }
            set
            {
                _readerCards = value;
                OnPropertyChanged(nameof(ReaderCards));
            }
        }
        public ObservableCollection<Book> BookCards
        {
            get { return _bookCards; }
            set
            {
                _bookCards = value;
                OnPropertyChanged(nameof(BookCards));
            }
        }
        public Book SelectedBookCard
        {
            get { return selectedBookCard; }
            set
            {
                selectedBookCard = value;
                OnPropertyChanged(nameof(SelectedBookCard));
            }
        }

        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                BookCards = booksReaderModel.search(thisreader,BookCards,Search);
            }
        }
        
        public string Take
        {
            get { return _take; }
            set
            {
                _take = value;
                OnPropertyChanged(nameof(Take));
                booksReaderModel.take(selectedBookCard);
            }
        }
        
        public RelayCommand NewOrder
        {
            get
            {
                return _newOrder ??
                    (_newOrder = new RelayCommand(obj =>
                    {
                        CatalogBooksReader catalog = new CatalogBooksReader(ref thisreader);
                        catalog.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
                    }));
            }
        }
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


    }
}
