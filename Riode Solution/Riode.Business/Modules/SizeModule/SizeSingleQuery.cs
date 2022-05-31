using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.SizeModule
{
    public class SizeSingleQuery : IRequest<ProductSize>
    {
        public int Id { get; set; }
        public class SizeSingleQueryHandler : IRequestHandler<SizeSingleQuery, ProductSize>
        {
            readonly RiodeDbContext db;
            public SizeSingleQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductSize> Handle(SizeSingleQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Sizes
                    .FirstOrDefaultAsync(ps => ps.Id == request.Id && ps.DeletedById == null, cancellationToken);
                if (entity==null)
                {
                    return null;
                }

                return entity;
            }
        }
    }
}
