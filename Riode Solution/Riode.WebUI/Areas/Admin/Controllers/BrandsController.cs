using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.AppCode.Modules.BrandModule;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandsController : Controller
    {
        readonly IMediator mediator;

        public BrandsController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        
        public async Task<IActionResult> Index()
        {
            var data = await mediator.Send(new BrandsAllQuery());

            return View(data);
        }

        // GET: Admin/Brands/Details/5
        public async Task<IActionResult> Details(BrandSingleQuery query)
        {
            var entity = await mediator.Send(query);
            if (entity == null)
            {
                return NotFound();
            }

            return View(entity);
        }

        // GET: Admin/Brands/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandCreateCommand command)
        {
            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Admin/Brands/Edit/5
        public async Task<IActionResult> Edit(BrandSingleQuery query)
        {
            var entity = await mediator.Send(query);
            if (entity == null)
            {
                return NotFound();
            }
            var command = new BrandEditCommand();
            command.Id = entity.Id;
            command.Name = entity.Name;
            return View(command);
        }

        // POST: Admin/Brands/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, BrandEditCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                var response = await mediator.Send(command);

                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BrandRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }

        //private bool BrandExists(int id)
        //{
        //    return db.Brands.Any(e => e.Id == id);
        //}
    }
}
