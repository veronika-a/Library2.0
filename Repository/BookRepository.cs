using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    class BookRepository : IBookRepository
    {
        private MyAppContext context;
        public bool Delete(int id)
        {
            Book book = context.Books.Find(id);
            if (book != null)
            {
                context.Books.Remove(book);
                return true;
            }
            else return false;
        }

        public IEnumerable<Book> GetAll()
        {
            return context.Books;
        }

        public Book GetById(int id)
        {
            return context.Books.Find(id);
        }

        public int GetCount()
        {
            int count = 0;
            foreach (Book book in context.Books)
            {
                count++;
            }
            return count;
        }

        public void Insert(Book book)
        {
            context.Books.Add(book);
        }

        public void Update(Book book)
        {
            context.Entry(book).State = EntityState.Modified;
        }


        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
