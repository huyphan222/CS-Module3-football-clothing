#pragma checksum "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e6747048ece98c9df2d892f363943a78e90a4912"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__CartPartial), @"mvc.1.0.view", @"/Views/Shared/_CartPartial.cshtml")]
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
#line 1 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Entities;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Models.ViewModels.DashBoardViewModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Models.ViewModels.ProductViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Models.ViewModels.RoleViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\_ViewImports.cshtml"
using ShopManagement.Models.ViewModels.CartItemViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml"
using Newtonsoft.Json;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e6747048ece98c9df2d892f363943a78e90a4912", @"/Views/Shared/_CartPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa5c42f57000657a8b00703c00730f6f327f894e", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__CartPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 7 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml"
  
    var session = HttpContextAccessor.HttpContext.Session;
    string jsoncart = session.GetString(ShopManagement.Controllers.CartController.CARTKEY);
    if (jsoncart != null)
    {
        var cart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(jsoncart);

#line default
#line hidden
#nullable disable
            WriteLiteral("        <span asp-route=\"cart\">(");
#nullable restore
#line 13 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml"
                           Write(cart.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</span>\r\n");
#nullable restore
#line 14 "C:\Users\USER\OneDrive\Desktop\CaseStudy\CaseStudy\ShopManagement\ShopManagement\Views\Shared\_CartPartial.cshtml"
    }

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
