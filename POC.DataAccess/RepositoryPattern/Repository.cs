using POC.DataAccess.POCEntityModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POC.DataAccess.RepositoryPattern
{
    public class Repository<TC, T> : IRepository<T>
        where T : class
        where TC : DbContext, new()
    {
        TC _entity = new TC();

        public TC Context
        {
            get
            {
                _entity.Database.CommandTimeout = 30;
                return _entity;
            }
            set { _entity = value; }
        }

        public void Add(T entity)
        {
            _entity.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _entity.Set<T>().Remove(entity);
        }

        public T FindBy(Func<T, bool> predicate)
        {
            using (var transaction = _entity.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                T data = _entity.Set<T>().Where(predicate).FirstOrDefault();
                transaction.Commit();
                return data;
            }
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            using (var transaction = _entity.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted))
            {
                IEnumerable<T> data = null;
                if (predicate == null)
                {
                    data = _entity.Set<T>();
                }
                else
                {
                    data = _entity.Set<T>().Where(predicate);
                }
                transaction.Commit();
                return data.ToList();
            }
        }

        public void Save()
        {
            _entity.SaveChanges();//This is unit of work
        }

        public void Update(T entity)
        {
            _entity.Entry(entity).State = EntityState.Modified;
            
        }
    }
}
