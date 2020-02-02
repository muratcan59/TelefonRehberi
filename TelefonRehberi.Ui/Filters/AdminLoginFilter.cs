using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TelefonRehberi.Filters
{
    public class AdminLoginFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
           //
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = HttpContext.Current.Session["LoginUser"];
            if (user == null)
            {
                filterContext.Result = new RedirectResult("/admin/kullanici/login");
            }
        }
    }
}