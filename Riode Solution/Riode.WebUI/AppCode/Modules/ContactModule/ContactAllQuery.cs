using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ContactModule
{
    public class ContactAllQuery : IRequest<IEnumerable<Contact>>
    {

        public class ContactAllQueryHandler : IRequestHandler<ContactAllQuery, IEnumerable<Contact>>
        {
            readonly RiodeDbContext db;
            public ContactAllQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<IEnumerable<Contact>> Handle(ContactAllQuery request, CancellationToken cancellationToken)
            {
                var data = await db.Contacts
                    .ToListAsync(cancellationToken);

                return data;
            }
        }
    }
}
