using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using CompDevices.WebUI.Models;

namespace CompDevices.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPage; i++)
            {
                // <a href="URL">...</a>
                // href - атрибут
                // "URL" - значение атрибута
                TagBuilder tag = new TagBuilder("a");   // Сконструировать дескриптор <a>
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                    tag.AddCssClass("selected");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
            // Результат!!!
            // <a class="selected" href="/?page=1">1</a><a href="/?page=2">2</a>
        }
    }
}