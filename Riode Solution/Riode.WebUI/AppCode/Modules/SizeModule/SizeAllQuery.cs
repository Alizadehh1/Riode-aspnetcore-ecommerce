using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.SizeModule
{
    public class SizeAllQuery : IRequest<IEnumerable<ProductSize>>
    {
        public class SizeAllQueryHandler : IRequestHandler<SizeAllQuery, IEnumerable<ProductSize>>
        {
            readonly RiodeDbContext db;
            public SizeAllQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<ProductSize>> Handle(SizeAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Sizes
                    .Where(ps=>ps.DeletedById==null)
                    .ToListAsync(cancellationToken);
                return entity;
            }
        }
    }
}
