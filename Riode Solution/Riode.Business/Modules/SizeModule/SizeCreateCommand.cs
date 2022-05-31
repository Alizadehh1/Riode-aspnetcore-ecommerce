using MediatR;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.SizeModule
{
    public class SizeCreateCommand : IRequest<ProductSize>
    {
        public string ShortName { get; set; }
        public string Name { get; set; }

        public class SizeCreateCommandHandler : IRequestHandler<SizeCreateCommand, ProductSize>
        {
            readonly RiodeDbContext db;
            public SizeCreateCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(SizeCreateCommand request, CancellationToken cancellationToken)
            {
                var data = new ProductSize();
                data.Name = request.Name;
                data.ShortName = request.ShortName;
                await db.Sizes.AddAsync(data);
                await db.SaveChangesAsync(cancellationToken);
                return data;
            }
        }
    }
}
