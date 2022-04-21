using Microsoft.AspNetCore.Mvc;
using Riode.WebUI.Models.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.WebUI.Controllers
{
    public class BlogController : Controller
    {
        readonly RiodeDbContext db;
        public BlogController(RiodeDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var data = db.Blogs
                .Where(b => b.DeletedById == null)
                .ToList();
            return View(data);
        }
        public IActionResult SinglePost(int id)
        {
            var data = db.Blogs
                .FirstOrDefault(b => b.DeletedById == null && b.Id == id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
    }
}
