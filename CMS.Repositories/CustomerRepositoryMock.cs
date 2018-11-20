using CMS.Model;
using CMS.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repositories
{
    internal class CustomerRepositoryMock : IRepository<Customer>
    {
        private readonly IDBContext dbContext;

        public CustomerRepositoryMock(IDBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(Customer entity)
        {
            this.dbContext.Add(entity);
        }

        public IEnumerable<Customer> Find(Expression<Func<Customer, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> FindAll()
        {
            throw new NotImplementedException();
        }

        public Customer FindByKey(Guid key)
        {
            throw new NotImplementedException();
        }

        public void Remove(Customer entity)
        {
            dbContext.Remove(entity);
        }

        public void RemoveByKey(Guid key)
        {
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }
    }
}
