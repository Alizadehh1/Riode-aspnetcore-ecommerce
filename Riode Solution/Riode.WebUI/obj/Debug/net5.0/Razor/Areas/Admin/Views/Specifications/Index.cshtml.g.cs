#pragma checksum "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "257d9b0155eeeb593f375373931c9ac29547d600"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Specifications_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Specifications/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 2 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.Models.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.Models.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.AppCode.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.AppCode.Modules.BrandModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.AppCode.Modules.BlogModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riode.WebUI.AppCode.Modules.ColorModule;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"257d9b0155eeeb593f375373931c9ac29547d600", @"/Areas/Admin/Views/Specifications/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"95273df94f4eeada2fea3cedc0336812c2f0c15c", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Specifications_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Riode.WebUI.Models.Entities.Specification>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/sweetalert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 10 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th class=\"actionBtns\">\r\n                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "257d9b0155eeeb593f375373931c9ac29547d6006572", async() => {
                WriteLiteral("<button class=\"btn btn-success btn-icon\"><i class=\"icofont-plus\"></i></button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 18 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 22 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td class=\"actionBtns\">\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "257d9b0155eeeb593f375373931c9ac29547d6008631", async() => {
                WriteLiteral("<button class=\"btn btn-warning btn-icon\"><i class=\"icofont-pencil-alt-5\"></i></button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 25 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
                                           WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "257d9b0155eeeb593f375373931c9ac29547d60010942", async() => {
                WriteLiteral("<button class=\"btn btn-info btn-icon\"><i class=\"icofont icofont-eye-alt\"></i></button>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 26 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
                                              WriteLiteral(item.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1031, "\"", 1082, 5);
            WriteAttributeValue("", 1041, "removeEntity(event,", 1041, 19, true);
#nullable restore
#line 27 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
WriteAttributeValue("", 1060, item.Id, 1060, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1068, ",\'", 1068, 2, true);
#nullable restore
#line 27 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
WriteAttributeValue("", 1070, item.Name, 1070, 10, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1080, "\')", 1080, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-danger btn-icon\">\r\n                        <i class=\"icofont-trash\"></i>\r\n                    </a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 32 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
            DefineSection("js", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "257d9b0155eeeb593f375373931c9ac29547d60014715", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>
        function removeEntity(ev, entityId, name) {
            swal({
                title: ""Are you sure?"",
                text: `${name} will be deleted, Are you sure?`,
                icon: ""warning"",
                buttons: true,
                dangerMode: true,
            })
                .then((willDelete) => {
                    if (willDelete) {
                        $.ajax({
                            url: `");
#nullable restore
#line 50 "C:\Users\alide\OneDrive\Desktop\Riode-aspnetcore-ecommerce\Riode Solution\Riode.WebUI\Areas\Admin\Views\Specifications\Index.cshtml"
                             Write(Url.Action("Delete"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"/${entityId}`,
                            type: 'post',
                            success: function (response) {
                                if (response.error==true) {
                                    toastr.error(response.message, ""Error!"");
                                    return;
                                }
                                toastr.success(""Successfully"", response.message)
                                $(`tr[data-entity-id=${entityId}]`).remove();
                            },
                            error: function (response) {
                                //toastr[""error""](""Unsuccessfully"", ""Data has not been deleted"")
                            }
                        })
                    }
                });
        }
    </script>
");
            }
            );
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Riode.WebUI.Models.Entities.Specification>> Html { get; private set; }
    }
}
#pragma warning restore 1591