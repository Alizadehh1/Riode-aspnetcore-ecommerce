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
    public class ColorAllQuery : IRequest<IEnumerable<ProductColor>>
    {
        public class ColorAllQueryHandler : IRequestHandler<ColorAllQuery, IEnumerable<ProductColor>>
        {
            readonly RiodeDbContext db;
            public ColorAllQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<ProductColor>> Handle(ColorAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Colors
                    .Where(pc => pc.DeletedById == null)
                    .ToListAsync(cancellationToken);
                return entity;
            }
        }
    }
}
