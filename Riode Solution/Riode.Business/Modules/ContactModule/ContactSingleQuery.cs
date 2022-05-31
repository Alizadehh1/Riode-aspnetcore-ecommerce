using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.ContactModule
{
    public class ContactSingleQuery : IRequest<Contact>
    {
        public int Id { get; set; }
        public class ContactSingleQueryHandler : IRequestHandler<ContactSingleQuery, Contact>
        {
            readonly RiodeDbContext db;
            public ContactSingleQueryHandler(RiodeDbContext db)
            {
                this.db = db;
            }
            public async Task<Contact> Handle(ContactSingleQuery request, CancellationToken cancellationToken)
            {

                var model = await db.Contacts
                    .FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken);

                return model;
            }
        }
    }
}
