using Riode.Data.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.Entities
{
    public class Category : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
        public virtual ICollection<Category> Children { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }

    }
}
