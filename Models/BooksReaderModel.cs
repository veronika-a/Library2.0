using Library.Repository;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Models
{
    public class BooksReaderModel 
    {
        
        public void take(Book selectedBookCard)
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                ReaderCard selectedReaderCards = readerCardRepository.GetAll(u => u.BookId == selectedBookCard.Id).FirstOrDefault();
                selectedReaderCards.DateTook = DateTime.Now;
                readerCardRepository.Update(selectedReaderCards);
            }
        }
        public ObservableCollection<Book> search(Reader thisreader, ObservableCollection<Book> BookCards, string Search)
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                var thisreaderCards = readerCardRepository.GetAll(u => u.ReaderId == thisreader.Id);
                BookRepository bookRepository = new BookRepository(appContext);
                BookCards = new ObservableCollection<Book>();
                foreach (var thisreaderCard in thisreaderCards)
                {
                    BookCards.Add(bookRepository.GetAll(u => u.Title.Contains(Search) & u.Id == thisreaderCard.BookId).FirstOrDefault());
                }
                return BookCards;
            }
        }
        public ObservableCollection<Book> GetBookCards(Reader thisreader, ObservableCollection<Book> BookCards)
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                ReaderCardRepository readerCardRepository = new ReaderCardRepository(appContext);
                var thisreaderCards = readerCardRepository.GetAll(u => u.ReaderId == thisreader.Id);
                BookRepository bookRepository = new BookRepository(appContext);
                BookCards = new ObservableCollection<Book>();
                foreach (var thisreaderCard in thisreaderCards)
                {
                    BookCards.Add(bookRepository.GetById(thisreaderCard.BookId));
                }
                return BookCards;
            }
        }

    }

}
