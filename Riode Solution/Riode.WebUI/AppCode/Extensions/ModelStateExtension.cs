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
        public static IActionContextAccessor AddModelError(this IActionContextAccessor ctx,string key,string message)
        {
            ctx.ActionContext.ModelState.AddModelError(key, message);
            return ctx;
        }

        public static bool ModelIsValid(this IActionContextAccessor ctx)
        {
            return ctx.ActionContext.ModelState.IsValid;
        }

        public static string GetError(this IActionContextAccessor ctx)
        {
            if (ctx.ModelIsValid())
            {
                return null;
            }
            return ctx.ActionContext.ModelState.First().Value.Errors.First().ErrorMessage;
        }

    }
}
