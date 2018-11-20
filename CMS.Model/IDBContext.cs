using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public interface IDBContext
    {
        ISet<Customer> Customers { get; }
        ISet<CardAcceptor> CardAcceptors { get; }
        ISet<Terminal> Terminals { get; }
        ISet<Card> Cards { get; }
        ISet<CardTransaction> CardTransactions { get; }

        void Add(EntityBase entity);
        void RemoveByKey(Guid key);
        void Remove(EntityBase entity);
        void Update(EntityBase entity);
    }
}
