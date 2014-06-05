using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.App_Start.Filters
{
    public class CheckAuthentication : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(filterContext.HttpContext.Request.Path.ToLower().Contains("/admin/") ||
                filterContext.HttpContext.Request.Path.ToLower().EndsWith("/admin"))
            {
                if(filterContext.HttpContext.Session["Auth"] == null ||
                    !Convert.ToBoolean(filterContext.HttpContext.Session["Auth"]))
                {
                    filterContext.Result = new RedirectResult("~/Security/");
                }
                
            }
        }
    }
}