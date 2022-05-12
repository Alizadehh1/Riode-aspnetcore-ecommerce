using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Riode.WebUI.AppCode.Modules.SubscribeModule;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Controllers
{
    public class HomeController : Controller
    {
        readonly RiodeDbContext db;
        readonly IMediator mediator;
        public HomeController(RiodeDbContext db,IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Faqs()
        {
            var faqs = db.Faqs.ToList();
            return View(faqs);
        }
        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact model)
        {
            if (!ModelState.IsValid)
            {
                return Json(new
                {
                    error = true,
                    message = ModelState.SelectMany(ms=>ms.Value.Errors).First().ErrorMessage
                });
            }
            await db.Contacts.AddAsync(model);
            await db.SaveChangesAsync();
            return Json(new
            {
                error = false,
                message = "Muracietiniz qeyde alindi!"
            });
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(SubscribeCreateCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }

        [HttpGet]
        [Route("/subscribe-confirm")]
        public async Task<IActionResult> SubscribeConfirm(SubscribeConfirmCommand command)
        {
            var response = await mediator.Send(command);

            return View(response);
        }
    }
}
