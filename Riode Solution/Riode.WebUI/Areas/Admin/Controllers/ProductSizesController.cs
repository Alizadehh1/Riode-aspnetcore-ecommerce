﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.AppCode.Modules.SizeModule;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductSizesController : Controller
    {
        private readonly RiodeDbContext db;
        private readonly IMediator mediator;

        public ProductSizesController(RiodeDbContext db,IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            return View(await db.Sizes.ToListAsync());
        }

        public async Task<IActionResult> Details(SizeSingleQuery query)
        {
            var entity = await mediator.Send(query);

            return View(entity);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ShortName,Name")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Add(productSize);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.Sizes.FindAsync(id);
            if (productSize == null)
            {
                return NotFound();
            }
            return View(productSize);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ShortName,Name")] ProductSize productSize)
        {
            if (id != productSize.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(productSize);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductSizeExists(productSize.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(productSize);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productSize = await db.Sizes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productSize == null)
            {
                return NotFound();
            }

            return View(productSize);
        }

        [HttpPost]
        public IActionResult Delete([FromRoute]int id)
        {
            var entity = db.Sizes.FirstOrDefault(s => s.Id == id);
            if (entity == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Movcud deyil"
                });
            }
            db.Sizes.Remove(entity);
            db.SaveChanges();
            return Json(new
            {
                error = false,
                message = "Ugurla silindi"
            });
        }

        private bool ProductSizeExists(int id)
        {
            return db.Sizes.Any(e => e.Id == id);
        }
    }
}
