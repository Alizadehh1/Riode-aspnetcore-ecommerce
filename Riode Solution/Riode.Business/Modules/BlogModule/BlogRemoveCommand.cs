using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Core.Infrastructure;
using Riode.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.BlogModule
{
    public class BlogRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int Id { get; set; }
        public class BlogRemoveCommandHandler : IRequestHandler<BlogRemoveCommand, CommandJsonResponse>
        {
            readonly RiodeDbContext db;
            public BlogRemoveCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(BlogRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Blogs
                    .FirstOrDefaultAsync(b => b.DeletedById == null && b.Id == request.Id, cancellationToken);

                if (entity==null)
                {
                    return new CommandJsonResponse(true, "Qeyd Movcud Deyil!");
                }

                entity.DeletedById = 1; //helelik
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                await db.SaveChangesAsync(cancellationToken);
                return new CommandJsonResponse(false, "Deleted Successfully");
            }
        }
    }
}
