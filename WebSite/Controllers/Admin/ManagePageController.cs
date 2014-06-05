using BusinessManager.Business;
using BusinessManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers.Admin
{
    public class ManagePageController : Controller
    {
        //
        // GET: /ManagePage/

        public ActionResult Index()
        {
            return View(PageBO.GetAll());
        }

        public ActionResult Edit(int id)
        {
            return View(PageBO.Get(id));
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(PageDataModel pagedm)
        {
            PageBO.Update(pagedm);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult Create(PageDataModel pagedm)
        {
            PageBO.Create(pagedm);

            return RedirectToAction("Index");
        }
    }
}
