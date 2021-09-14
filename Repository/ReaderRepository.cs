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
    public class ReaderRepository : IReaderRepository
    {
        DbContext _context;
        DbSet<Reader> _dbSet;

        public ReaderRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<Reader>();
        }

        public void Delete(Reader entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Reader> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public List<Reader> GetAll(Expression<Func<Reader, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public Reader GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(Reader entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(Reader entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
