using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.BlogModule
{
    public class BlogAllQuery : IRequest<IEnumerable<Blog>>
    {
        public class BlogAllQueryHandler : IRequestHandler<BlogAllQuery, IEnumerable<Blog>>
        {
            readonly RiodeDbContext db;
            public BlogAllQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<Blog>> Handle(BlogAllQuery request, CancellationToken cancellationToken)
            {
                var entity = await db.Blogs
                 .Include(b => b.Category)
                .Where(b => b.DeletedById == null)
                .ToListAsync(cancellationToken);
                return entity;
            }
        }
    }
}
