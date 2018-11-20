using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Model
{
    public class Institution : EntityBase
    {
        public Institution(Guid id, string fullname)
        {
            Id = id.Equals(Guid.Empty) ? Guid.NewGuid() : id;
            Fullname = fullname;
        }

        public string Fullname { get; private set; }
    }
}
