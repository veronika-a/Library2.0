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
    
    public class NewBookViewModel : INotifyPropertyChanged
    {
        private string title;
        private string ganre;
        private string about;
        private string publisher;
        private int? publicationDate;
        private string coverArtist;

        private RelayCommand _SaveCommand;
        public event EventHandler Closing;

        public bool Validated = false;

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

                            var book = new Book()
                            {
                                Title = this.title,
                                Ganre = this.ganre,
                                CoverArtist = this.coverArtist,
                                Publisher = this.publisher,
                                PublicationDate = this.publicationDate,
                                About = this.about
                            };

                            bookRepository.Insert(book);
                            MessageBox.Show($" {book.Title} !", "New Book", MessageBoxButton.OK, MessageBoxImage.Information);

                        }

                    }));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
