using BusinessManager.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class SecurityController : Controller
    {
        //
        // GET: /Security/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            if (UserBO.CheckUser(email, password))
            {
                Session["Auth"] = true;
                return RedirectToAction("Index", "ManagePage");
            }
            else
            {
                ViewBag.error = true;
                return View();
            }
            
        }

    }
}
