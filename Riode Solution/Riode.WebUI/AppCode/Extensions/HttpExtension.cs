using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Riode.WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Riode.WebUI.AppCode.Extensions
{
    public static partial class Extension
    {
        public static string GetAppLink(this IActionContextAccessor ctx)
        {
            string host = ctx.ActionContext.HttpContext.Request.Host.ToString();
            string scheme = ctx.ActionContext.HttpContext.Request.Scheme;
            return $"{scheme}://{host}";
        }

    }
}
