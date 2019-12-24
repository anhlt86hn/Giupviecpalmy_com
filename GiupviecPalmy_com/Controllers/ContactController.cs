using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GiupviecPalmy_com.Models;

namespace GiupviecPalmy_com.Controllers
{
    public class ContactController : Controller
    {
        giupviecpalmy_com_dbEntities db = new giupviecpalmy_com_dbEntities();
        public ActionResult ContactIndex()
        {
            return View();
        }

        public ActionResult ContactCreate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactCreate(FormCollection collection)
        {
            try
            {
               
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ContactEdit(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactEdit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("ContactIndex");
            }
            catch
            {
                return View();
            }
        }

       
        public ActionResult ContactDelete(int id)
        {
            return View();
        }

    }
}
