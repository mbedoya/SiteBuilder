using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManageUserController : Controller
    {
        //
        // GET: /ManageUser/

        public ActionResult Index()
        {
            return View(UserBO.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(UserBO.Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(UserDataModel user)
        {
            UserBO.Update(user);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(UserDataModel user)
        {
            UserBO.Create(user);

            return RedirectToAction("Index");
        }
    }
}
