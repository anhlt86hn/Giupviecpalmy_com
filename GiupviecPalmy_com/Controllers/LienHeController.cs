using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Data;
using System.Data.Linq;
using System.Data.Mapping;
using GiupviecPalmy_com.Models;
using GiupviecPalmy_com.ViewModels;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using System.Net;
using PagedList;
using PagedList.Mvc;

namespace GiupviecPalmy_com.Controllers
{
    public class LienHeController : Controller
    {
        giupviecpalmy_com_dbEntities db = new giupviecpalmy_com_dbEntities();
        public ActionResult Index()
        {
            string menu_name = "";
            var menu = db.Menus.Where(m => m.Active == true && m.Name == "Liên hệ").SingleOrDefault();         
            menu_name = menu.Name;
               
            #region[Title, Keyword, Deskription]
            if (menu.Title.Length > 0) { ViewBag.tit = menu.Title; } else { ViewBag.tit = menu.Name; }
            if (menu.Description.Length > 0) { ViewBag.des = menu.Description; } else { ViewBag.des = menu.Name; }
            if (menu.Keyword.Length > 0) { ViewBag.key = menu.Keyword; } else { ViewBag.key = menu.Name; }
            #endregion
            
            string address_img = "";
            string email_img = "";
            string phone_img = "";
            string web_img = "";
                     
            var list = db.Images.Where(m => m.Active == true && m.Position == 100).ToList();

            address_img = list[0].Picture;
            email_img = list[1].Picture;
            phone_img = list[2].Picture;
            web_img = list[3].Picture;

            ViewBag.AddressImage = address_img;
            ViewBag.EmailImage = email_img;
            ViewBag.PhoneImage = phone_img;
            ViewBag.WebImage = web_img;
            ViewBag.MenuName = menu_name;
            return View();
        }
    }
}
