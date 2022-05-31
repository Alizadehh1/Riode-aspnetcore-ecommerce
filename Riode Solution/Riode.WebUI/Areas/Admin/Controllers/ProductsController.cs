using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riode.Core.Extensions;
using Riode.Core.Infrastructure;
using Riode.Business.Modules.ProductModule;
using Riode.Data.DataContexts;
using Riode.Data.Entities;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly RiodeDbContext _context;
        private readonly IMediator mediator;

        public ProductsController(RiodeDbContext context, IMediator mediator)
        {
            _context = context;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var riodeDbContext = _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(i => i.Images.Where(i => i.IsMain == true));
            return View(await riodeDbContext.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");

            ViewData["Colors"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["Sizes"] = new SelectList(_context.Sizes, "Id", "Name");
            ViewBag.Specifications = _context.Specification.Where(s => s.DeletedById == null)
                .ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductCreateCommand command)
        {
            var product = await mediator.Send(command);

            if (product?.ValidationResult != null && !product.ValidationResult.IsValid)
            {
                return Json(product.ValidationResult);
            }

            return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat, yeni mehsulun kodu:{product.Product.Id}"));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Images)
                .Include(p => p.Specifications)
                .Include(p => p.Pricings)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            ViewData["Colors"] = new SelectList(_context.Colors, "Id", "Name");
            ViewData["Sizes"] = new SelectList(_context.Sizes, "Id", "Name");
            ViewBag.Specifications = _context.Specification.Where(s => s.DeletedById == null)
                .ToList();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductEditCommand model)
        {

            var product = await mediator.Send(model);

            if (product?.ValidationResult != null && !product.ValidationResult.IsValid)
            {
                return Json(product.ValidationResult);
            }

            return Json(new CommandJsonResponse(false, $"Ugurlu emeliyyat, yeni mehsulun kodu:{product.Product.Id}"));
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.Id == id);
        }
    }
}
