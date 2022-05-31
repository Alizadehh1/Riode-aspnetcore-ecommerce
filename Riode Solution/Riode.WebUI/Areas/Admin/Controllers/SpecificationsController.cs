using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riode.Data.DataContexts;
using Riode.Data.Entities;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SpecificationsController : Controller
    {
        private readonly RiodeDbContext db;

        public SpecificationsController(RiodeDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            return View(db.Specification
                .ToList()
                .Where(s => s.DeletedById == null));
        }

        // GET: Admin/Specifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await db.Specification
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedById == null);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        // GET: Admin/Specifications/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Specification specification)
        {
            if (ModelState.IsValid)
            {
                db.Add(specification);
                await db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(specification);
        }

        // GET: Admin/Specifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await db.Specification
                .FirstOrDefaultAsync(s => s.Id == id && s.DeletedById == null);
            if (specification == null)
            {
                return NotFound();
            }
            return View(specification);
        }

        // POST: Admin/Specifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id,CreatedById,CreatedDate,DeletedById,DeletedDate")] Specification specification)
        {
            if (id != specification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    db.Update(specification);
                    await db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpecificationExists(specification.Id))
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
            return View(specification);
        }

        // GET: Admin/Specifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var specification = await db.Specification
                .FirstOrDefaultAsync(m => m.Id == id);
            if (specification == null)
            {
                return NotFound();
            }

            return View(specification);
        }

        // POST: Admin/Specifications/Delete/5
        [HttpPost]
        public IActionResult Delete([FromRoute]int id)
        {
            var entity = db.Specification.FirstOrDefault(s => s.Id == id && s.DeletedById == null);
            if (entity == null)
            {
                return Json(new
                {
                    error = true,
                    message = "Movcud deyil"
                });
            }
            entity.DeletedById = 1;
            entity.DeletedDate = DateTime.UtcNow.AddHours(4);
            db.SaveChanges();
            return Json(new
            {
                error = false,
                message = "Ugurla silindi"
            });
        }

        private bool SpecificationExists(int id)
        {
            return db.Specification.Any(e => e.Id == id);
        }
    }
}
