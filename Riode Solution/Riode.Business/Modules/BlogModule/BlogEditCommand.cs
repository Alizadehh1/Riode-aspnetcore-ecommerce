using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Riode.Core.Extensions;
using Riode.Data.DataContexts;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Riode.Business.Modules.BlogModule
{
    public class BlogEditCommand : IRequest<Blog>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Paragraph { get; set; }
        public string ImagePath { get; set; }
        public int? CategoryId { get; set; }
        public IFormFile File { get; set; }
        public int[] TagIds { get; set; }
        public ICollection<BlogPostTag> TagCloud { get; set; }


        public class BlogEditCommandHandler : IRequestHandler<BlogEditCommand, Blog>
        {
            readonly RiodeDbContext db;
            readonly IWebHostEnvironment env;
            readonly IActionContextAccessor ctx;
            public BlogEditCommandHandler(RiodeDbContext db,IWebHostEnvironment env, IActionContextAccessor ctx)
            {
                this.db = db;
                this.env = env;
                this.ctx = ctx;
            }
            public async Task<Blog> Handle(BlogEditCommand request, CancellationToken cancellationToken)
            {
                if (ctx.ModelIsValid())
                {
                    if (request.File == null && string.IsNullOrEmpty(request.ImagePath))
                    {
                        ctx.AddModelError("ImagePath", "Image Cannot be empty");
                    }
                    var currentEntity = await db.Blogs
                    .FirstOrDefaultAsync(b => b.Id == request.Id && b.DeletedById == null, cancellationToken);
                    if (currentEntity == null)
                    {
                        return null;
                    }
                    string oldFileName = currentEntity.ImagePath;
                    if (request.File != null)
                    {
                        string fileExtension = Path.GetExtension(request.File.FileName);
                        string name = $"blog-{Guid.NewGuid()}{fileExtension}";
                        string physicalPath = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", name);
                        using (var fs = new FileStream(physicalPath, FileMode.Create, FileAccess.Write))
                        {
                            request.File.CopyTo(fs);
                        }
                        currentEntity.ImagePath = name;
                        string physicalPathOld = Path.Combine(env.ContentRootPath, "wwwroot", "uploads", "images", oldFileName);
                        if (System.IO.File.Exists(physicalPathOld))
                        {
                            System.IO.File.Delete(physicalPathOld);
                        }
                    }
                    currentEntity.CategoryId = request.CategoryId;
                    currentEntity.Title = request.Title;
                    currentEntity.Paragraph = request.Paragraph;
                    if (request.TagIds != null && request.TagIds.Length > 0)
                    {
                        foreach (var item in request.TagIds)
                        {
                            if (db.BlogPostTagCloud.Any(bptc => bptc.PostTagId == item && bptc.BlogId == request.Id))
                            {
                                continue;
                            }
                            await db.BlogPostTagCloud.AddAsync(new BlogPostTag
                            {
                                BlogId = request.Id,
                                PostTagId = item
                            }, cancellationToken);
                        }
                        await db.SaveChangesAsync(cancellationToken);
                    }
                    return currentEntity;
                }
                return null;
            }
        }
    }
}
