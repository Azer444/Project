#pragma checksum "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\Category\Detail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f6f37728b2caf2d5db0e74654046bcb4b800c692"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_AdminArea_Views_Category_Detail), @"mvc.1.0.view", @"/Areas/AdminArea/Views/Category/Detail.cshtml")]
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
#line 1 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.Helper;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels.ProductViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels.SliderViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels.InfoViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels.ShoeViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\_ViewImports.cshtml"
using BackEndProject.ViewModels.TopImageModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f6f37728b2caf2d5db0e74654046bcb4b800c692", @"/Areas/AdminArea/Views/Category/Detail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"38b3ce269dd7a8c04602c9ab4d00efdbc1e2e5d0", @"/Areas/AdminArea/Views/_ViewImports.cshtml")]
    public class Areas_AdminArea_Views_Category_Detail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Category>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\Category\Detail.cshtml"
  
    ViewData["Title"] = "Detail";
    Layout = "~/Areas/AdminArea/Views/Shared/_AdminLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "C:\Users\azerh\Desktop\BackEnd-Lahiye\Project\BackEndProject\Areas\AdminArea\Views\Category\Detail.cshtml"
Write(Model.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Category> Html { get; private set; }
    }
}
#pragma warning restore 1591
