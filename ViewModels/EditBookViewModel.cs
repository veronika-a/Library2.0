using Library.Models;
using Library.Views;
using System;
using System.ComponentModel;
using WcfServiceLibrary;

namespace Library.ViewModels
{

    public class EditBookViewModel : INotifyPropertyChanged
    {
        private Book thisbook;
        private Reader thisreader;
        Service1 service1;

        public Book Thisbook { get => thisbook; set => thisbook = value; }

        private string title;
        private string ganre;
        private string about;
        private string publisher;
        private int? publicationDate;
        private string coverArtist;

        public EditBookViewModel(Book book, Reader reader)
        {
                Thisbook = book;
            thisreader = reader;

                title = book.Title;
                ganre = book.Ganre;
                coverArtist = book.CoverArtist;
                publisher = book.Publisher;
                publicationDate = book.PublicationDate;
                about = book.About;

                service1 = new Service1();
            
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
                        if (thisbook.Title != null)
                        {
                            thisbook.Title = Title;
                            thisbook.Ganre = Ganre;
                            thisbook.CoverArtist = CoverArtist;
                            thisbook.Publisher = Publisher;
                            thisbook.PublicationDate = PublicationDate;
                            thisbook.About = About;

                            service1.editBookViewModel_save(thisbook);

                            CatalogBooksAdmin catalogBooksAdmin = new CatalogBooksAdmin(ref thisreader);
                            catalogBooksAdmin.Show();
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
                        CatalogBooksAdmin catalog = new CatalogBooksAdmin(ref thisreader);
                        catalog.Show();
                        Closing?.Invoke(this, EventArgs.Empty);
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
