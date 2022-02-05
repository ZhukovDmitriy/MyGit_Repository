#pragma checksum "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "47721a87d0ef521b12dd89f6c8c4a04fa7aa93c7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_RequestCash_Index), @"mvc.1.0.view", @"/Views/RequestCash/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"47721a87d0ef521b12dd89f6c8c4a04fa7aa93c7", @"/Views/RequestCash/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7114978914865b2dc4110ea17c2e80c686ea9638", @"/Views/_ViewImports.cshtml")]
    public class Views_RequestCash_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<ApplicationForCash.Models.ViewModels.CashRequestViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1 class=\"page-theme\">Заявка</h1>\r\n<p class=\"page-description\">Приветствуем вас: <span style=\"font-weight:bold;\">");
#nullable restore
#line 4 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
                                                                         Write(Model.User.FirstName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span></p>\r\n\r\n");
#nullable restore
#line 6 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
 using (Html.BeginForm())
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form\">\r\n\r\n        <label>Адрес департамента: </label>\r\n        <p>\r\n            ");
#nullable restore
#line 13 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
       Write(Html.DropDownListFor(m => m.SelectedDepartmentID,
new SelectList(Model.Departments, "DepartmentID", "Address")));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <label>Сумма к выдаче: </label>\r\n        <p>");
#nullable restore
#line 18 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
      Write(Html.EditorFor(m => m.Amount, new { htmlAttributes = new { min = 1, max = 99999 } }));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n        <label>Валюта: </label>\r\n        <p>\r\n            ");
#nullable restore
#line 22 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
       Write(Html.DropDownListFor(m => m.SelectedCurrency,
       new SelectList(Model.Currency)));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </p>\r\n\r\n        <input class=\"submit-btn\" type=\"submit\" value=\"Отправить\" />\r\n    </div>\r\n");
#nullable restore
#line 28 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<p class=\"page-description\">Проверка статуса заявки</p>\r\n\r\n");
#nullable restore
#line 32 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
 if (Model.CashRequest != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div id=\"request-status\">\r\n");
#nullable restore
#line 35 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
         if (Model.CashRequest.RequestStatus == true)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p style=\"color:green;\">");
#nullable restore
#line 37 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
                               Write(Model.CashRequest.StatusComment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 38 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <p style=\"color:red;\">");
#nullable restore
#line 41 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
                             Write(Model.CashRequest.StatusComment);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 42 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <p>Сумма: ");
#nullable restore
#line 44 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
             Write(Model.CashRequest.Amount);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        <p>Валюта: ");
#nullable restore
#line 45 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
              Write(Model.CashRequest.Currency);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n    </div>\r\n");
#nullable restore
#line 47 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 49 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
 if (TempData["Message"] != null)
{ 

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p id=\"temp-data\" style=\"margin: 2%; color: red; font-weight:bold;\">");
#nullable restore
#line 51 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
                                                                   Write(TempData["Message"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 52 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 55 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
Write(Html.ValidationSummary(true));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 56 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
 using (Html.BeginForm("StatusCheck", "RequestCash", FormMethod.Post))
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"form\">\r\n        <input id=\"status-input\" type=\"number\" name=\"orderNum\" min=\"1\" max=\"99999\" />\r\n        <input class=\"submit-btn\" type=\"submit\" value=\"Проверить\" onclick=\"return ValidateStatusInput();\" />\r\n    </div>\r\n");
#nullable restore
#line 62 "D:\MyProjects\Projects_Test_Employers_PrivatBank\ApplicationForCash\ApplicationForCash\Views\RequestCash\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<script type=""text/javascript"">

    function ValidateStatusInput() {

        var input = document.getElementById('status-input');

        if (input.value == """") {

            alert(""Введите значение!"")

            return false;
        }

        return true;
    }

</script>

");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<ApplicationForCash.Models.ViewModels.CashRequestViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591