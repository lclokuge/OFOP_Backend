using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        //void Add(IList<T> entities);
        //void Add(IEnumerable<T> entities);
        //void Update(T entity);
        //void Update(IList<T> entities);
        //void Update(IEnumerable<T> entities);
        //void AddOrUpdate(Expression<Func<T, object>> exp, T entity);
        //void AddOrUpdate(T entity);
        //void AddOrUpdate(IEnumerable<T> entities);
        //bool Delete(int id);
        //bool Delete(T entity);
        //bool Delete(long id);
        //bool Delete(string id);
        //bool Delete(Expression<Func<T, bool>> where);
        IQueryable<T> GetAll();
        T Get(int id);
        T Get(long id);
        T Get(string id);
        T Get(Expression<Func<T, bool>> where);
        //Task<IQueryable<T>> GetMany(Expression<Func<T, bool>> where);

        IQueryable<T> GetMany(Expression<Func<T, bool>> where);
        //void Save();
        //int Count(Expression<Func<T, bool>> where);
        //int Count();
    }
}
