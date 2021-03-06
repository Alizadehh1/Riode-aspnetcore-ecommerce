using MediatR;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.BrandModule
{
    public class BrandCreateCommand : IRequest<Brand>
    {
        public string Name { get; set; }
        public class BrandCreateCommandHandler : IRequestHandler<BrandCreateCommand, Brand>
        {
            readonly RiodeDbContext db;
            public BrandCreateCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<Brand> Handle(BrandCreateCommand request, CancellationToken cancellationToken)
            {
                var brand = new Brand();
                brand.Name = request.Name;

                await db.Brands.AddAsync(brand);
                await db.SaveChangesAsync(cancellationToken);

                return brand;
            }
        }
    }
}
