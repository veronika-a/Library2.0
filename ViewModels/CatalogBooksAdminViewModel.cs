using Library.Models;
using Library.Repository;
using Library.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using WcfServiceLibrary;

namespace Library.ViewModels
{
    
    public class CatalogBooksAdminViewModel : INotifyPropertyChanged
    {
        public event EventHandler Closing;
        private RelayCommand _Edit;
        private RelayCommand _Delete;
        Service1 service1;
        Reader thisreader;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
       // Book _book;

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
        public CatalogBooksAdminViewModel(Reader reader)
        {
            thisreader = reader;
             service1 = new Service1();
            Books = new ObservableCollection<Book>(service1.catalogBooksAdminModel_getBooks());
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

        

        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                OnPropertyChanged(nameof(Search));
                Books = new ObservableCollection<Book>(service1.catalogBooksAdminModel_getBooks().Where(i => i.Title.Contains(Search)));
              

            }
        }

        public RelayCommand Edit
        {
            get
            {

                return _Edit ??
                    (_Edit = new RelayCommand(obj =>
                    {
                        if (selectedBook != null)
                        {
                            service1.catalogBooksAdminModel_edit(selectedBook);
                            EditBook editBook = new EditBook(ref selectedBook, ref thisreader);
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
                        service1.catalogBooksAdminModel_delete(selectedBook);
                            CatalogBooksAdmin catalog = new CatalogBooksAdmin(ref thisreader);
                            catalog.Show();
                            Closing?.Invoke(this, EventArgs.Empty);
                        
                    }));
            }
        }
        private RelayCommand _addBook;

        public RelayCommand AddBook
        {
            get
            {
                return _addBook ??
                    (_addBook = new RelayCommand(obj =>
                    {
                        NewBook newBook = new NewBook(ref thisreader);
                        newBook.Show();
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
