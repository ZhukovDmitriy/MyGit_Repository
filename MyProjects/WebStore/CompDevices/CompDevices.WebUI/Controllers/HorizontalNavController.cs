using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompDevices.WebUI.Controllers
{
    public class HorizontalNavController : Controller
    {
        public PartialViewResult Menu()
        {
            return PartialView();
        }

        protected override void HandleUnknownAction(string actionName)
        {
            try
            {
                this.View(actionName).ExecuteResult(this.ControllerContext);
            }
            catch (Exception ex)
            {
                Response.Redirect("Страница не найдена!");
            }
        }
    }
}