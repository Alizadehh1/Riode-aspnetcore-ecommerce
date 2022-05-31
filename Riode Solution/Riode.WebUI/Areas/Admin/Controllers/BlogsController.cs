using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Riode.Business.Modules.BlogModule;
using Riode.Data.DataContexts;
using Riode.Data.Entities;

namespace Riode.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogsController : Controller
    {
        private readonly RiodeDbContext db;
        readonly IMediator mediator;

        public BlogsController(RiodeDbContext db,IMediator mediator)
        {
            this.db = db;
            this.mediator = mediator;
        }

        public async Task<IActionResult> Index(BlogAllQuery query)
        {
            var entity = await mediator.Send(query);
            return View(entity);
        }

        public async Task<IActionResult> Details(BlogSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog==null)
            {
                return NotFound();
            }
            return View(blog);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name");
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BlogCreateCommand command)
        {
            var response = await mediator.Send(command);
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", command.CategoryId);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            return View(command);
        }

        public async Task<IActionResult> Edit(BlogSingleQuery query)
        {
            var blog = await mediator.Send(query);
            if (blog == null)
            {
                return NotFound();
            }
            var command = new BlogEditCommand();
            command.Id = blog.Id;
            command.Title = blog.Title;
            command.Paragraph = blog.Paragraph;
            command.ImagePath = blog.ImagePath;
            command.CategoryId = blog.CategoryId;
            command.TagCloud = blog.TagCloud;
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", blog.CategoryId);
            return View(command);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] int id, BlogEditCommand command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }
            
            await mediator.Send(command);
            ViewData["TagId"] = new SelectList(db.PostTags, "Id", "Name");
            ViewData["CategoryId"] = new SelectList(db.Categories, "Id", "Name", command.CategoryId);
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> Delete(BlogRemoveCommand command)
        {
            var response = await mediator.Send(command);
            return Json(response);
        }
    }
}
