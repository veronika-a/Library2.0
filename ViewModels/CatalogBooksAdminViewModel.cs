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
    
    public class CatalogBooksAdminViewModel : INotifyPropertyChanged
    {
        //ObservableCollection<UserModel> selectedUsers;
        public event EventHandler Closing;
        private RelayCommand _Edit;
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
        public CatalogBooksAdminViewModel()
        {
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
                // || i.FirstName.Contains(Search)
                // || i.SecondName.Contains(Search))); ;

            }
        }
        public RelayCommand Edit
        {
            get
            {

                return _Edit ??
                    (_Edit = new RelayCommand(obj =>
                    {
                        using (MyAppContext appContext = new MyAppContext())
                        {
                            BookRepository bookRepository = new BookRepository(appContext);
                            var book = selectedBook;
                            EditBook editBook = new EditBook(ref book);
                            editBook.Show();
                            Closing?.Invoke(this, EventArgs.Empty);
                        }
                    }));
            }
        }
        public RelayCommand Delete
        {
            get
            {

                return _Delete ??
                    (_Delete = new RelayCommand(obj =>
                    {
                        using (MyAppContext appContext = new MyAppContext())
                        {
                            BookRepository bookRepository = new BookRepository(appContext);
                            var book = selectedBook;
                            bookRepository.Delete(book);
                            CatalogBooksAdmin catalog = new CatalogBooksAdmin();
                            catalog.Show();
                            Closing?.Invoke(this, EventArgs.Empty);
                        }
                    }));
            }
        }

    }
}
