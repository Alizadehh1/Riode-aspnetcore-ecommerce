using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Riode.WebUI.Models.DataContexts;
using Riode.WebUI.Models.ViewModels;
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
            var post = db.Blogs
                .Include(b => b.TagCloud)
                .ThenInclude(b => b.PostTag)
                .FirstOrDefault(b => b.Id == id && b.DeletedById == null);

            if (post==null)
            {
                return NotFound();
            }

            var viewModel = new SinglePostViewModel();
            viewModel.Post = post;
            var tagIdsQuery = post.TagCloud.Select(t => t.PostTagId);

            viewModel.RelatedPost = db.Blogs
                .Include(b => b.TagCloud)
                .Where(b => b.Id != id && b.DeletedById == null
                && b.TagCloud.Any(tc => tagIdsQuery.Any(qId => qId == tc.PostTagId)))
                .OrderByDescending(b=>b.Id)
                .Take(15)
                .ToList();

            return View(viewModel);
        }
    }
}
