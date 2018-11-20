using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public enum CustomerType
    {
        Unknown = 0,
        Retail = 1,
        Corporate = 2
    }

    public class Customer : EntityBase
    {
        public Customer(Guid id, string firstName, string lastName, CustomerType customerType)
        {
            Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public CustomerType CustomerType { get; private set; }
    }
}
