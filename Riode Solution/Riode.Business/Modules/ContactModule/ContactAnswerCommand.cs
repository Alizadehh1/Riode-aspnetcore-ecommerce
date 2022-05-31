using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riode.Core.Extensions;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.ContactModule
{
    public class ContactAnswerCommand : IRequest<Contact>
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Cannot be Empty")]
        [MinLength(3, ErrorMessage = "Cannot be less than three symbol")]
        public string AnswerMessage { get; set; }
        public class ContactAnswerCommandHandler : IRequestHandler<ContactAnswerCommand, Contact>
        {
            readonly RiodeDbContext db;
            readonly IActionContextAccessor ctx;
            public ContactAnswerCommandHandler(RiodeDbContext db,IActionContextAccessor ctx)
            {
                this.db = db;
                this.ctx = ctx;
            }

            public async Task<Contact> Handle(ContactAnswerCommand request, CancellationToken cancellationToken)
            {
                l1:
                if (!ctx.ModelIsValid())
                {
                    return new Contact
                    {
                        AnswerMessage = request.AnswerMessage,
                        Id = request.Id
                    };
                }

                var post = await db.Contacts
                    .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

                if (post==null)
                {
                    ctx.AddModelError("AnswerMessage", "Not Found");
                    goto l1;
                }
                else if(post.AnsweredById!=null)
                {
                    ctx.AddModelError("AnswerMessage", "Already Answered");
                }
                post.AnsweredById = 1;
                post.AnswerDate = DateTime.UtcNow.AddHours(4);
                post.AnswerMessage = request.AnswerMessage;
                await db.SaveChangesAsync(cancellationToken);
                return post;
            }
        }
    }
}
