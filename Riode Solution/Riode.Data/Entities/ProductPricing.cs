using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class ProductPricing : HistoryEntity
    {
        public int ColorId { get; set; }
        public virtual ProductColor Color { get; set; }
        public int SizeId { get; set; }
        public virtual ProductSize Size { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public double Price { get; set; }

    }
}
