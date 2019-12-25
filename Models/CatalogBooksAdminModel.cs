using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class CatalogBooksAdminModel
    {
        public void edit(Book selectedBook)
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                BookRepository bookRepository = new BookRepository(appContext);
                var book = selectedBook;

            }
        }

        public void delete(Book selectedBook)
        {
            using (MyAppContext appContext = new MyAppContext())
            {
                BookRepository bookRepository = new BookRepository(appContext);
                var book = selectedBook;
                bookRepository.Delete(book);

            }
        }

    }
}
