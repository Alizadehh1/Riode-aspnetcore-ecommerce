using Riode.Data.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class PostTag : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<BlogPostTag> TagCloud { get; set; }
    }
    public class BlogPostTag
    {
        
        public int BlogId { get; set; }
        public virtual Blog Blog { get; set; }
        public int PostTagId { get; set; }
        public virtual PostTag PostTag { get; set; }
    }
}
