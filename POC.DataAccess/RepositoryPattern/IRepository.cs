using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POC.DataAccess.RepositoryPattern
{
    public interface IRepository<T> where T:class
    {
        IEnumerable<T> GetAll(Func<T,bool> predicate = null);
        T FindBy(Func<T, bool> predicate);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        void Save();
    }
}
