#pragma checksum "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e4feb5c3488945b931444b7dd7c694aa347c183"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_Login), @"mvc.1.0.view", @"/Views/Account/Login.cshtml")]
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
#line 1 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\_ViewImports.cshtml"
using ApplicationForCash.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e4feb5c3488945b931444b7dd7c694aa347c183", @"/Views/Account/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7114978914865b2dc4110ea17c2e80c686ea9638", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationForCash.Models.ViewModels.LoginModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
  
    ViewBag.Title = "Авторизация";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1 class=\"page-theme\">Авторизация</h1>\r\n\r\n<p class=\"page-description\">Пожалуйста авторизируйтесь, чтобы получить доступ к сайту.</p>\r\n\r\n");
#nullable restore
#line 12 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 13 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form\">\r\n\r\n        <label>Логин: </label>\r\n        <p>");
#nullable restore
#line 18 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
      Write(Html.EditorFor(m => m.Login));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <label>Пароль: </label>\r\n        <p>");
#nullable restore
#line 20 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
      Write(Html.EditorFor(m => m.Password));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        ");
#nullable restore
#line 22 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
   Write(Html.HiddenFor(m => m.ReturnUrl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n        <input class=\"submit-btn\" type=\"submit\" value=\"Войти\" />\r\n    </div>\r\n");
#nullable restore
#line 26 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Account\Login.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationForCash.Models.ViewModels.LoginModel> Html { get; private set; }
    }
}
#pragma warning restore 1591