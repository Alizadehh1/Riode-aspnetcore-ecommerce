using MediatR;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ColorModule
{
    public class ColorCreateCommand : IRequest<ProductColor>
    {
        public string Name { get; set; }
        public string HexCode { get; set; }

        public class ColorCreateCommandHandler : IRequestHandler<ColorCreateCommand, ProductColor>
        {
            readonly RiodeDbContext db;
            public ColorCreateCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ColorCreateCommand request, CancellationToken cancellationToken)
            {
                var productColor = new ProductColor();
                productColor.Name = request.Name;
                productColor.HexCode = request.HexCode;
                await db.Colors.AddAsync(productColor);
                await db.SaveChangesAsync(cancellationToken);
                return productColor;
            }
        }
    }
}
