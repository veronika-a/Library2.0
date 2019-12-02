using Library.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepository<TEntity> where TEntity:class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        int GetCount();
        TEntity GetById(int id);
        bool Delete(int id);
        IEnumerable<TEntity> GetAll();


    }

}
