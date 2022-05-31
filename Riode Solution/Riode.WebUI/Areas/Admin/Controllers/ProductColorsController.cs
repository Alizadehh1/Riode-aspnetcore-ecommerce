using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riode.Business.Modules.ColorModule;
using Riode.Data.DataContexts;
using Riode.Data.Entities;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductColorsController : Controller
    {
        private readonly IMediator mediator;

        public ProductColorsController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task<IActionResult> Index(ColorAllQuery query)
        {
            var entity = await mediator.Send(query);
            return View(entity);
        }
        public async Task<IActionResult> Details(ColorSingleQuery query)
        {
            var entity = await mediator.Send(query);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,HexCode")] ColorCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        public async Task<IActionResult> Edit(ColorSingleQuery query)
        {
            var entity = await mediator.Send(query);
            if (entity==null)
            {
                return NotFound();
            }
            var command = new ColorEditCommand();
            command.Id = entity.Id;
            command.Name = entity.Name;
            command.HexCode = entity.HexCode;
            return View(command);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute]int id,ColorEditCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                var data = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(ColorRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
