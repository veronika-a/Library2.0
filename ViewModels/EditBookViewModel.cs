using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Library.ViewModels
{

    public class EditBookViewModel : INotifyPropertyChanged
    {
        private Book book;

        public Book Book { get => book; set => book = value; }

        private string title;
        private string ganre;
        private string about;
        private string publisher;
        private int? publicationDate;
        private string coverArtist;

        public EditBookViewModel(Book book)
        {
            Book = book;

            title =  this.book.Title;
            ganre = this.book.Ganre;
            coverArtist = this.book.CoverArtist;
            publisher = this.book.Publisher;
            publicationDate = this.book.PublicationDate;
            about = this.book.About;
        }
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Ganre
        {
            get { return ganre; }
            set
            {
                ganre = value;
                OnPropertyChanged(nameof(Ganre));
            }
        }
        public string Publisher
        {
            get { return publisher; }
            set
            {
                publisher = value;
                OnPropertyChanged(nameof(Publisher));
            }
        }
        public int? PublicationDate
        {
            get { return publicationDate; }
            set
            {
                publicationDate = value;
                OnPropertyChanged(nameof(PublicationDate));
            }
        }
        public string About
        {
            get { return about; }
            set
            {
                about = value;
                OnPropertyChanged(nameof(About));
            }
        }
        public string CoverArtist
        {
            get { return coverArtist; }
            set
            {
                coverArtist = value;
                OnPropertyChanged(nameof(CoverArtist));
            }
        }

        private RelayCommand _SaveCommand;
        public RelayCommand SaveCommand
        {
            get
            {

                return _SaveCommand ??
                    (_SaveCommand = new RelayCommand(obj =>
                    {


                        using (MyAppContext appContext = new MyAppContext())
                        {
                            BookRepository bookRepository = new BookRepository(appContext);
                            //var book = bookRepository.GetAll(u => u.Title == title || u.Edition == Edition).FirstOrDefault();


                            book.Title = Title;
                            book.Ganre = Ganre;
                            book.CoverArtist = CoverArtist;
                            book.Publisher = Publisher;
                            book.PublicationDate = PublicationDate;
                            book.About = About;


                            bookRepository.Update(book);
                            MessageBox.Show($" {book.Title} !", "Update Book", MessageBoxButton.OK, MessageBoxImage.Information);

                        }

                    }));
            }
        }

        public event EventHandler Closing;

        public bool Validated = false;


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }

}
