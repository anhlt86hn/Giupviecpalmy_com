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

namespace GiupviecPalmy_com.Controllers.Default
{
    public class DefaultController : Controller
    {
        giupviecpalmy_com_dbEntities data = new giupviecpalmy_com_dbEntities();
       
       
        public ActionResult Menu(string tag)
        {
            string menu_name = "";
            string menu_link = "";
            string chuoi = "";
           
            var list = data.Menus.Where(m => m.Tag == tag).SingleOrDefault();
            menu_name = list.Name;
            menu_link = list.Link;
            if (list != null)
            {
               
                chuoi += "<p>" + list.Content + "</p>";
                chuoi += "<p>" + list.Detail + "</p>";

                #region[Title, Keyword, Deskription]
                if (list.Title.Length > 0) { ViewBag.tit = list.Title; } else { ViewBag.tit = list.Name; }
                if (list.Description.Length > 0) { ViewBag.des = list.Description; } else { ViewBag.des = list.Name; }
                if (list.Keyword.Length > 0) { ViewBag.key = list.Keyword; } else { ViewBag.key = list.Name; }
                #endregion
            }
            ViewBag.MenuContent = chuoi;
            ViewBag.MenuLink = menu_link;
            ViewBag.MenuName = menu_name;
           
            return View();
        }

    }
}
