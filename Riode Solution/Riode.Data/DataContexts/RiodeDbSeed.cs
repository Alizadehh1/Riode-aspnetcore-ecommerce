using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Riode.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode.Data.DataContexts
{
    public static class RiodeDbSeed
    {
        static public void InitDb(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<RiodeDbContext>();
                db.Database.Migrate();
                InitTags(db);
                InitBrands(db);
                InitSizes(db);
            }
            

        }

        private static void InitTags(RiodeDbContext db)
        {
            if (!db.PostTags.Any())
            {
                db.PostTags.AddRange(new[]
                {
                    new PostTag{Name="Bag"},
                    new PostTag{Name="Classic"},
                    new PostTag{Name="Converse"},
                    new PostTag{Name="Leather"},
                    new PostTag{Name="Fit"},
                    new PostTag{Name="Green"},
                    new PostTag{Name="Man"},
                    new PostTag{Name="Jeans"},
                    new PostTag{Name="Women"}
                });

                db.SaveChanges();
            }
        }

        private static void InitSizes(RiodeDbContext db)
        {
            
        }

        private static void InitBrands(RiodeDbContext db)
        {
            
        }
    }
}
