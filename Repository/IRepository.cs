using Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepository<TEntity> 
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        int GetCount();
        TEntity GetById(int id);
        void Delete(TEntity entity);
        IEnumerable<TEntity> GetAll();
        List<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);


    }

}
