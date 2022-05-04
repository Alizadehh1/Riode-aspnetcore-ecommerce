using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.AppCode.Infrastructure;
using Riode.WebUI.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ColorModule
{
    public class ColorRemoveCommand : IRequest<CommandJsonResponse>
    {
        public int Id { get; set; }
        public class ColorRemoveCommandHandler : IRequestHandler<ColorRemoveCommand, CommandJsonResponse>
        {
            readonly RiodeDbContext db;
            public ColorRemoveCommandHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<CommandJsonResponse> Handle(ColorRemoveCommand request, CancellationToken cancellationToken)
            {
                var entity = await db.Colors
                    .FirstOrDefaultAsync(pc => pc.Id == request.Id && pc.DeletedById == null, cancellationToken);
                if (entity==null)
                {
                    return new CommandJsonResponse(true, "Qeyd Movcud Deyil!");
                }

                entity.DeletedById = 1;
                entity.DeletedDate = DateTime.UtcNow.AddHours(4);
                return new CommandJsonResponse(false, "Ugurla silindi!");
            }
        }
    }
}
