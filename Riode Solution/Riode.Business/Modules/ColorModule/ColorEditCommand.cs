using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.ColorModule
{
    public class ColorEditCommand : IRequest<ProductColor>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string HexCode { get; set; }
        public class ColorEditCommandHandler : IRequestHandler<ColorEditCommand, ProductColor>
        {
            readonly RiodeDbContext db;
            public ColorEditCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ColorEditCommand request, CancellationToken cancellationToken)
            {
                var productColor = await db.Colors
                    .FirstOrDefaultAsync(pc => pc.Id == request.Id && pc.DeletedById == null, cancellationToken);

                if (productColor==null)
                {
                    return null;
                }
                productColor.Name = request.Name;
                productColor.HexCode = request.HexCode;
                await db.SaveChangesAsync(cancellationToken);
                return productColor;
            }
        }
    }
}
