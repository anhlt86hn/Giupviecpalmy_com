using GiupviecPalmy_com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GiupviecPalmy_com.ViewModels
{
    public class MyCookie
    {
        public static string CookieName { get; set; }
        //public virtual Product Pro { get; set; }

        //public void SetCookie(Product pro)
        //{
        //    HttpCookie myCookie = HttpContext.Current.Request.Cookies[CookieName] ?? new HttpCookie(CookieName);
        //    myCookie.Values["ProId"] = pro.Id.ToString();
        //    myCookie.Values["Count"] = DateTime.Now.ToString();
        //    myCookie.Expires = DateTime.Now.AddDays(365);
        //    HttpContext.Current.Response.Cookies.Add(myCookie);
        //}
    }
}