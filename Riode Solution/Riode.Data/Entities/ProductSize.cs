using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class ProductSize : BaseEntity
    {
        public string ShortName { get; set; }
        public string Name { get; set; }
    }
}
