using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Terminal: EntityBase
    {
        public Terminal(Guid id, string description)
        {
            Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
            Description = description;
        }

        public string Description { get; private set; }
    }
}
