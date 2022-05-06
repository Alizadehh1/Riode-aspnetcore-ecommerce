using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Riode.WebUI.AppCode.Extensions;
using Riode.WebUI.AppCode.Infrastructure;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Modules.SubscribeModule
{
    public class SubscribeCreateCommand : IRequest<CommandJsonResponse>
    {
        [Required(ErrorMessage = "Cannot Empty")]
        [EmailAddress(ErrorMessage = "Email does not contain")]
        public string Email { get; set; }
        public class SubscribeCreateCommandHandler : IRequestHandler<SubscribeCreateCommand, CommandJsonResponse>
        {
            readonly RiodeDbContext db;
            readonly IConfiguration configuration;
            readonly IActionContextAccessor ctx;
            public SubscribeCreateCommandHandler(RiodeDbContext db,IConfiguration configuration,IActionContextAccessor ctx)
            {
                this.db = db;
                this.configuration = configuration;
                this.ctx = ctx;
            }
            public async Task<CommandJsonResponse> Handle(SubscribeCreateCommand request, CancellationToken cancellationToken)
            {
                var displayName = configuration["emailAccount:displayName"];
                var smtpServer = configuration["emailAccount:smtpServer"];
                var smtpPort = Convert.ToInt32(configuration["emailAccount:smtpPort"]);
                var userName = configuration["emailAccount:userName"];
                var password = configuration["emailAccount:password"];
                var cc = configuration["emailAccount:cc"];

                var subscribe = await db.Subscribes
                    .FirstOrDefaultAsync(s=>s.Email.Equals(request.Email),cancellationToken);
                if (subscribe==null)
                {
                    subscribe = new Subscribe();
                    subscribe.Email = request.Email;
                    await db.Subscribes.AddAsync(subscribe, cancellationToken);
                    await db.SaveChangesAsync(cancellationToken);
                }
                else if (subscribe.EmailSended == true)
                {
                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "Siz artiq abunesiniz"
                    };
                }
                

                try
                {

                    string token = $"{subscribe.Id}-{subscribe.Email}".Encrypt();
                    string link = $"{ctx.GetAppLink()}/subscribe-confirm?token={token}";

                    SmtpClient client = new SmtpClient(smtpServer,smtpPort);
                    client.Credentials = new NetworkCredential(userName, password);
                    client.EnableSsl = true;

                    var from = new MailAddress(userName, displayName);
                    MailMessage message = new MailMessage(from, new MailAddress(subscribe.Email));
                    message.Subject = "Riode Confirmation Mail";
                    message.Body = $"Please confirm subscribtion with <a href=\"{link}\">link</a>";
                    message.IsBodyHtml = true;
                    string[] ccs = cc.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    foreach (var item in ccs)
                    {
                        message.Bcc.Add(item);
                    }

                    client.Send(message);

                    subscribe.EmailSended = true;
                    await db.SaveChangesAsync(cancellationToken);
                    
                }
                catch (Exception ex)
                {

                    return new CommandJsonResponse
                    {
                        Error = true,
                        Message = "E BIR BIR"
                    };
                }

                return new CommandJsonResponse
                {
                    Error = false,
                    Message = $"Abuneliyi tamamlamaq ucun \"{subscribe.Email}\"-e gonderilmish emeliyyati yerine yetirin!"
                };
            }
        }
    }
}
