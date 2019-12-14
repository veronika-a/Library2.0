using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
   
    public class ReaderCardRepository : IReaderCardRepository
    {
        DbContext _context;
        DbSet<ReaderCard> _dbSet;

        public ReaderCardRepository(DbContext context)
        {
            _context = context;
            _dbSet = context.Set<ReaderCard>();
        }

        public void Delete(ReaderCard entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<ReaderCard> GetAll()
        {
            return _dbSet.AsNoTracking().ToList();
        }

        public List<ReaderCard> GetAll(Expression<Func<ReaderCard, bool>> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public ReaderCard GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public int GetCount()
        {
            throw new NotImplementedException();
        }

        public void Insert(ReaderCard entity)
        {
            _context.Entry(entity).State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Update(ReaderCard entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
