using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OFOP.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {

        protected OFDPContext _entities;

        protected DbSet<T> dbSet;


        /// <summary>
        /// Creates instance with default ProxyCreationEnabled = false
        /// </summary>
        public RepositoryBase(OFDPContext context)
        {
            _entities = context;
            dbSet = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                dbSet.Add(entity);
                _entities.SaveChanges();

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw dbEx;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public T Get(long id)
        {
            throw new NotImplementedException();
        }

        public T Get(string id)
        {
            throw new NotImplementedException();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return dbSet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IQueryable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return  dbSet.Where(where);
        }

      
    }
}
