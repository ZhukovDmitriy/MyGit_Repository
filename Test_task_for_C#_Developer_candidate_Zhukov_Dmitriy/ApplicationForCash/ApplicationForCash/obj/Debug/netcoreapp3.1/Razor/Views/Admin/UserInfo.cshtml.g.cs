#pragma checksum "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "4e966a72351fc1fd59f9b754008a9da383a90d47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Admin_UserInfo), @"mvc.1.0.view", @"/Views/Admin/UserInfo.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e966a72351fc1fd59f9b754008a9da383a90d47", @"/Views/Admin/UserInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7114978914865b2dc4110ea17c2e80c686ea9638", @"/Views/_ViewImports.cshtml")]
    public class Views_Admin_UserInfo : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationForCash.Models.ViewModels.UserInfoViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<input class=\"UI-location\" type=\"button\" value=\"админ\"");
            BeginWriteAttribute("onclick", "\r\n       onclick=\"", 119, "\"", 188, 3);
            WriteAttributeValue("", 137, "location.href=\'", 137, 15, true);
#nullable restore
#line 4 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
WriteAttributeValue("", 152, Url.Action("RequestList", "Admin"), 152, 35, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 187, "\'", 187, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n\r\n<h1 class=\"page-theme\">Информация о пользователе</h1>\r\n\r\n<div class=\"user-data\">\r\n    <p><span>Фамилия: </span>");
#nullable restore
#line 9 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
                        Write(Model.User.LastName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    <p><span>Имя: </span>");
#nullable restore
#line 10 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
                    Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n</div>\r\n\r\n<h2>История заявок</h2>\r\n\r\n<table class=\"Grid\">\r\n    <tr>\r\n        <th>Номер запроса:</th>\r\n        <th>Сумма | Валюта:</th>\r\n        <th>Отделение:</th>\r\n        <th>Статус:</th>\r\n        <th>Действие:</th>\r\n    </tr>\r\n");
#nullable restore
#line 23 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
     foreach (var item in Model.CashRequests)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>");
#nullable restore
#line 26 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
           Write(item.RequestID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            <td>\r\n                ");
#nullable restore
#line 28 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
           Write(item.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 28 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
                          Write(item.Currency);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>");
#nullable restore
#line 30 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
           Write(item.DepartmentAddress);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n");
#nullable restore
#line 32 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
             if (item.RequestStatus == false)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td style=\"color:red;\">");
#nullable restore
#line 34 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
                                  Write(item.StatusComment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 35 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <td style=\"color:green;\">");
#nullable restore
#line 38 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
                                    Write(item.StatusComment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 39 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <td>\r\n                <input type=\"button\" value=\"Одобрить\"");
            BeginWriteAttribute("onclick", "\r\n                       onclick=\"", 1181, "\"", 1392, 3);
            WriteAttributeValue("", 1215, "location.href=\'", 1215, 15, true);
#nullable restore
#line 42 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
WriteAttributeValue("", 1230, Url.Action("EditRequest","Admin",
                                              new { requestId = item.RequestID, confirmStatus = true, userId = item.UserID }), 1230, 161, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1391, "\'", 1391, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n                <input type=\"button\" value=\"Отклонить\"");
            BeginWriteAttribute("onclick", "\r\n                       onclick=\"", 1452, "\"", 1664, 3);
            WriteAttributeValue("", 1486, "location.href=\'", 1486, 15, true);
#nullable restore
#line 45 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
WriteAttributeValue("", 1501, Url.Action("EditRequest","Admin",
                                              new { requestId = item.RequestID, confirmStatus = false, userId = item.UserID }), 1501, 162, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1663, "\'", 1663, 1, true);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 49 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\Admin\UserInfo.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationForCash.Models.ViewModels.UserInfoViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591