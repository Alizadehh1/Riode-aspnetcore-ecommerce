using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class Specification : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<ProductSpecification> Specifications { get; set; }
    }
}
