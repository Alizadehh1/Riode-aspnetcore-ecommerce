using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Riode.Data.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        readonly RiodeDbContext db;
        public HeaderViewComponent(RiodeDbContext db)
        {
            this.db = db;
        }
        public IViewComponentResult Invoke()
        {

            var data = db.Categories
                .Select(c => new
                {
                    Id = c.Id,
                    Name = c.ParentId == null ? c.Name : $"- {c.Name}"
                })
                .ToList();
            ViewBag.Categories = new SelectList(data, "Id", "Name");

            return View();
        }
    }
}
