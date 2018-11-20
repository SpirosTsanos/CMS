using CMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories.Interfaces
{
    internal interface IRepository<T> where T : EntityBase
    {
        T FindByKey(Guid key);
        IEnumerable<T> FindAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Remove(T entity);
        void RemoveByKey(Guid key);
        void Update(T entity);
    }
}
