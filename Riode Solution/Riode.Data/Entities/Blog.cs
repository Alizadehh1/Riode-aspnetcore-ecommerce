using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; } 
        public virtual Category Category { get; set; }
        public virtual ICollection<BlogPostTag> TagCloud { get; set; }
    }
}
