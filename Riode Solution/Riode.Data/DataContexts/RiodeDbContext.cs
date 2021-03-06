using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Riode.Data.Entities;
using Riode.Data.Entities.Membership;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.DataContexts
{
    public class RiodeDbContext : IdentityDbContext<RiodeUser,RiodeRole,int,RiodeUserClaim,RiodeUserRole,RiodeUserLogin,RiodeRoleClaim,RiodeUserToken>
    {
        public RiodeDbContext(DbContextOptions options)
            :base(options)
        {

        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<BlogPostTag> BlogPostTagCloud { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }
        public DbSet<Specification> Specification { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductSize> Sizes { get; set; }
        public DbSet<ProductColor> Colors { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<ProductSpecification> ProductSpecifications { get; set; }
        public DbSet<ProductPricing> ProductPricings { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BlogPostTag>(e=>
            {
                e.HasKey(k => new { k.BlogId, k.PostTagId });
            });

            modelBuilder.Entity<ProductSpecification>(e=>
            {
                e.HasKey(k => new { k.ProductId, k.SpecificationId });
            });
            modelBuilder.Entity<ProductPricing>(e=>
            {
                e.HasKey(k => new { k.ProductId, k.ColorId,k.SizeId });
            });
        }
    }
}
