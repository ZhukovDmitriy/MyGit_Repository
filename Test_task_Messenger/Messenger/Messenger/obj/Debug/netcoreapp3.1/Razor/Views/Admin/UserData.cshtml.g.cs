#pragma checksum "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b45dcba5be51ed768cbfa4f32ca749b05097bd3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserData), @"mvc.1.0.view", @"/Views/Admin/UserData.cshtml")]
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
#line 1 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\_ViewImports.cshtml"
using Messenger.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b45dcba5be51ed768cbfa4f32ca749b05097bd3f", @"/Views/Admin/UserData.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7b197af2853ef9a20d600b3d088d4e85ba2443d2", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserData : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<User>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
  
    ViewBag.Title = "Данные всех пользователей";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<input class=\"nav-btn\" type=\"button\" value=\"Вернуться назад\"");
            BeginWriteAttribute("onclick", "\r\n       onclick=\"", 172, "\"", 235, 3);
            WriteAttributeValue("", 190, "location.href=\'", 190, 15, true);
#nullable restore
#line 9 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
WriteAttributeValue("", 205, Url.Action("Index", "Admin"), 205, 29, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 234, "\'", 234, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n<h1 class=\"page-theme\">Данные пользователей</h1>\r\n\r\n<p class=\"page-description\">Учетные данные всех пользователей</p>\r\n\r\n");
#nullable restore
#line 15 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
  
    int i = 1;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 19 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>Отсутствуют пользователи в списке</p>\r\n");
#nullable restore
#line 22 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <table class=\"grid\">\r\n        <tr>\r\n            <th>№:</th>\r\n            <th>Фамилия:</th>\r\n            <th>Имя:</th>\r\n            <th>Логин:</th>\r\n            <th>Пароль:</th>\r\n            <th>Доступ:</th>\r\n        </tr>\r\n");
#nullable restore
#line 34 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>");
#nullable restore
#line 37 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(i);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 38 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(item.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 39 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(item.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 40 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(item.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 41 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(item.Password);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 42 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
               Write(item.Role.RoleName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"

            {
                i++;
            }
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </table>\r\n");
#nullable restore
#line 50 "D:\MyProjects\Projects_Test_Employers\Messenger\Messenger\Views\Admin\UserData.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<User>> Html { get; private set; }
    }
}
#pragma warning restore 1591
