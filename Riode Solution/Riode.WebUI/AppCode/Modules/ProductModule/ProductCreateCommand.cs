using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ProductModule
{
    public class ProductCreateCommand : IRequest<Product>
    {
        public string Name { get; set; }
        public string StockKeepingUnit { get; set; }
        public int BrandId { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public SpecificationKeyValue[] Specification { get; set; }
        public ProductPricing[] Pricing { get; set; }
        public ImageItem[] Images { get; set; }

        public class ProductCreateCommandHandler : IRequestHandler<ProductCreateCommand, Product>
        {
            readonly RiodeDbContext db;
            readonly IWebHostEnvironment env;
            readonly IActionContextAccessor ctx;
            public ProductCreateCommandHandler(RiodeDbContext db,IWebHostEnvironment env,IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<Product> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }

    public class SpecificationKeyValue
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
    public class ProductPricing
    {
        public int ProductId { get; set; }
        public int SizeId { get; set; }
        public int ColorId { get; set; }
        public double Price { get; set; }
    }
    public class ImageItem
    {
        public int? Id { get; set; }
        public bool IsMain { get; set; }
        public string TempPath { get; set; }
        public IFormFile File { get; set; }
    }
}
