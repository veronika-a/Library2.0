using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    class BookRepository : IBookRepository
    {
        DbContext _context;
        DbSet<Book> _dbSet;

        public BookRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Book>();
        }
        public void Delete(Book entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IEnumerable<Book> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public List<Book> GetAll(Expression<Func<Book, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public Book GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(Book entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Book entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
