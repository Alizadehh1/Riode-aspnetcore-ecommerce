﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ColorModule
{
    public class ColorSingleQuery : IRequest<ProductColor>
    {
        public int Id { get; set; }
        public class ColorSingleQueryHandler : IRequestHandler<ColorSingleQuery, ProductColor>
        {
            readonly RiodeDbContext db;
            public ColorSingleQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<ProductColor> Handle(ColorSingleQuery request, CancellationToken cancellationToken)
            {
                
                var productColor = await db.Colors
                    .FirstOrDefaultAsync(m => m.Id == request.Id,cancellationToken);
                return productColor;
            }
        }
    }
}
