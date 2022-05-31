using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Core.Infrastructure;
using Riode.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.BrandModule
{
    public class BrandRemoveCommand : IJsonRequest
    {
        public int Id { get; set; }

        public class BrandRemoveCommandHandler : IJsonRequestHandler<BrandRemoveCommand>
        {
            readonly RiodeDbContext db;
            public BrandRemoveCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(BrandRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Brands
                       .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedById == null, cancellationToken);

                if (entity == null)
                {
                    return new CommandJsonResponse(true,"Qeyd movcud deyil!");
                }

                entity.DeletedById = 1;
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);

                return new CommandJsonResponse(false, "Qeyd silindi!");
            }
        }
    }
}
