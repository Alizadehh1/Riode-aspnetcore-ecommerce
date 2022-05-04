using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Models.DataContexts
{
    public class RiodeDbContext : DbContext
    {
        public RiodeDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Specification> Specification { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<BlogPostTag> BlogPostTagCloud { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPostTag>(e=>
            {
                e.HasKey(k => new { k.BlogId, k.PostTagId });
            });
        }
    }
}
