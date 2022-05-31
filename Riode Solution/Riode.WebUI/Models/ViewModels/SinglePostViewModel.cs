using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.ViewModels
{
    public class SinglePostViewModel
    {
        public Blog Post { get; set; }
        public IEnumerable<Blog> RelatedPost { get; set; }
    }
}
