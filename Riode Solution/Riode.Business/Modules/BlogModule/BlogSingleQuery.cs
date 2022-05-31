using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.BlogModule
{
    public class BlogSingleQuery : IRequest<Blog>
    {
        public int Id { get; set; }
        public class BlogSingleQueryHandler : IRequestHandler<BlogSingleQuery, Blog>
        {
            readonly RiodeDbContext db;
            public BlogSingleQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<Blog> Handle(BlogSingleQuery request, CancellationToken cancellationToken)
            {

                var blog = await db.Blogs
                    .Include(b => b.Category)
                    .Include(b=> b.TagCloud)
                    .FirstOrDefaultAsync(m => m.Id == request.Id && m.DeletedById == null, cancellationToken);

                return blog;
            }
        }
    }
}
