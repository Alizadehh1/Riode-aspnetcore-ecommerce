using MediatR;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.ContactModule
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
