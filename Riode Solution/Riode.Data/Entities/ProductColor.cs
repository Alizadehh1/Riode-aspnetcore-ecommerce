using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class ProductColor : BaseEntity
    {
        public string Name { get; set; }
        public string HexCode { get; set; }
    }
}
