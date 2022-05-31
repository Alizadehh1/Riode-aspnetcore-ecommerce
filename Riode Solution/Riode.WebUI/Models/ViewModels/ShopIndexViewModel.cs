using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.ViewModels
{
    public class ShopIndexViewModel
    {
        public List<Brand> Brands { get; set; }
        public List<ProductSize> ProductSizes { get; set; }
        public List<ProductColor> ProductColors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
