using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Packaging;
using GiupviecPalmy_com.Models;

namespace GiupviecPalmy_com.Controllers
{
    public class My_PartialviewController : Controller
    {
        giupviecpalmy_com_dbEntities db = new giupviecpalmy_com_dbEntities();

        #region[Header]

        #region[Pretty Menu]
        public ActionResult _PrettyMenu()
        {
            string menu = "";
            var cat = db.Menus.Where(m => m.Active == true && m.Level.Length == 5 && m.Position == 1).OrderBy(m=>m.Ord).ToList();
            var list = db.Images.Where(l => l.Position == 2 && l.Active == true).Take(5).ToList();
            //var list = db.Images.Where(m => m.Active == true && m.Position == 100).Take(5).ToList();
            for (int i = 0; i < cat.Count; i++)
            {
                if (i == 0)
                {
                    menu += "<span id=\"menu_no_" + (i + 1) + "\" class=\"mmenu_items  mid\">";
                }
                else if (i == 1)
                {
                    menu += "<span id=\"menu_no_" + (i + 1) + "\" class=\"mmenu_items  top\">";
                }
                else if (i == 2)
                {
                    menu += "<span id=\"menu_no_" + (i + 1) + "\" class=\"mmenu_items  behind\">";
                }
                else if (i == 3)
                {
                    menu += "<span id=\"menu_no_" + (i + 1) + "\" class=\"mmenu_items  top\">";
                }
                else if (i == 4)
                {
                    menu += "<span id=\"menu_no_" + (i + 1) + "\" class=\"mmenu_items  mid last\">";
                }


                menu += "<div class=\"mmenu_items_pad\">";
                menu += "<div class=\"mmenu_img\">";
                menu += "<table width=\"100%\" height=\"100%\" cellpadding=\"0\" cellspacing=\"0\" border=\"0\">";

                menu += "<tr><td align=\"center\"><a href=\"" + cat[i].Tag + "\"><img src=\"" + list[i].Picture + "\" width=\"206\" height=\"115\" alt=\"" + list[i].Name + "\"></a></td></tr>";
                //menu += "<tr><td align=\"center\"><a href=\"" + cat[i].Tag + "\"><img src=\"" + list[i].Source + "\" width=\"206\" height=\"115\" alt=\"" + list[i].Alternative + "\"></a></td></tr>";
                //menu += "<tr><td align=\"center\"><a href=\"" + cat[i].Tag + "\"><img src=\"../uploads/files/menu_" + (i + 1) + ".jpg\" width=\"206\" height=\"115\" alt=\"Menu " + (i + 1) + "\" title=\"menu no." + (i + 1) + "\"></a></td></tr>";
                menu += "</table></div>";
                menu += "<div class=\"mmenu_name\"><a href=\"" + cat[i].Link + "\" title=\"" + cat[i].Title + "\" rel=\"menu\"><h2>" + cat[i].Name + "</h2></a></div></div>";
                menu += "<div class=\"shadow_menu\"></div></span>";
            }
            cat.Clear();
            cat = null;
            ViewBag.PrettyMenu = menu;
            return PartialView();
        }
        #endregion

        #region[Main Menu]
        public ActionResult _MainMenu()
        {
            string menu = "";
            var cat = db.Menus.Where(c => c.Active == true && c.Level.Length == 5).OrderBy(c => c.Ord).ToList();
            for (int i = 0; i < cat.Count; i++)
            {
                List<Menu> menus = db.Menus.ToList();
                List<Menu> catsub = new List<Menu>();
                string levelm = cat[i].Level;
                catsub = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == levelm && m.Active == true).OrderBy(m => m.Level).ToList();
                if (catsub.Count > 0)
                {
                    if ((Request.Url.ToString().IndexOf(cat[i].Link) > 0 && cat[i].Link != "/") || (cat[i].Link == "/"))
                    //if ((Request.Url.ToString().IndexOf(cat[i].Link) > 0 && cat[i].Link != "/") || (cat[i].Link == "/" && (Request.Url.ToString() == "http://localhost:1584/" || Request.Url.ToString() == "http://ilovestyle.vn/")))
                    {
                        if (i == 0)
                        {

                            menu += "<li><a class=\"active\" href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a>";
                            //chuoi += "<li style=\"background: none\"><a class=\"active\" href=\"" + cat[i].Link + "\">" + cat[i].Name + "</a>";
                        }
                        else
                        {

                            menu += "<li><a class=\"active\" href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a>";
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {

                            menu += "<li><a href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a>";
                            //chuoi += "<li style=\"background: none\"><a href=\"" + cat[i].Link + "\">" + cat[i].Name + "</a>";
                        }
                        else
                        {

                            menu += "<li><a href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a>";
                        }
                    }
                    menu += "<ul class=\"sub-menu\">";
                    for (int k = 0; k < catsub.Count; k++)
                    {
                        string levelm10 = catsub[k].Level;
                        List<Menu> catsub10 = new List<Menu>();
                        catsub10 = db.Menus.Where(m => m.Level.Length == 15 && m.Level.Substring(0, 10) == levelm10 && m.Active == true).OrderBy(m => m.Level).ToList();
                        if (catsub10.Count == 0)
                        {
                            menu += "<li><a href=\"" + catsub[k].Link + "\"><span>" + catsub[k].Name + "</span></a></li>";
                        }
                        else
                        {
                            menu += "<li class=\"sub\"><a href=\"" + catsub[k].Link + "\"><span>" + catsub[k].Name + "</span></a>";
                            menu += "<ul>";
                            for (int n = 0; n < catsub10.Count; n++)
                            {
                                string levelm15 = catsub10[n].Level;
                                List<Menu> catsub15 = new List<Menu>();
                                catsub15 = db.Menus.Where(m => m.Level.Length == 20 && m.Level.Substring(0, 15) == levelm15 && m.Active == true).OrderBy(m => m.Level).ToList();
                                if (catsub15.Count == 0)
                                {
                                    menu += "<li><a href=\"" + catsub10[n].Link + "\"><span>" + catsub10[n].Name + "</span></a></li>";
                                }
                                else
                                {
                                    menu += "<li class=\"sub\"><a href=\"" + catsub10[n].Link + "\"><span>" + catsub10[n].Name + "</span></a>";
                                    menu += "<ul>";
                                    for (int m = 0; m < catsub15.Count; m++)
                                    {
                                        menu += "<li><a href=\"" + catsub15[m].Link + "\"><span>" + catsub15[m].Name + "</span></a></li>";
                                    }
                                    menu += "</ul></li>";
                                }
                            }
                            menu += "</ul></li>";
                        }
                    }
                    menu += "</ul></li>";
                }
                else
                {
                    if ((Request.Url.ToString().IndexOf(cat[i].Link) > 0 && cat[i].Link != "/") || (cat[i].Link == "/"))
                    //if ((Request.Url.ToString().IndexOf(cat[i].Link) > 0 && cat[i].Link != "/") || (cat[i].Link == "/" && (Request.Url.ToString() == "http://localhost:1584/" || Request.Url.ToString() == "http://ilovestyle.vn/")))
                    {
                        if (i == 0)
                        {

                            menu += "<li><a class=\"active\" href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a></li>";
                            //chuoi += "<li style=\"background: none\"><a class=\"active\" href=\"" + cat[i].Link + "\">" + cat[i].Name + "</a></li>";
                        }
                        else
                        {

                            menu += "<li><a class=\"active\" href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a></li>";
                        }
                    }
                    else
                    {
                        if (i == 0)
                        {

                            menu += "<li><a href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a></li>";
                            //chuoi += "<li style=\"background: none\"><a href=\"" + cat[i].Link + "\">" + cat[i].Name + "</a></li>";
                        }
                        else
                        {

                            menu += "<li><a href=\"" + cat[i].Link + "\"><span>" + cat[i].Name + "</span></a></li>";
                        }
                    }
                }
            }
            ViewBag.MainMenu = menu;
            cat.Clear();
            cat = null;
            return PartialView();
        }
        #endregion
        
        #endregion

        #region[Headline]
        public ActionResult _Headline()
        {
            return PartialView();
        }
        #endregion

        #region[Slide]
        public ActionResult _Slide()
        {
            string str = "";
            var list = db.Images.Where(m => m.Position == 3 && m.Active == true).OrderBy(m => m.Orders).ToList();
            str = "<ol class=\"carousel-indicators\">";

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i == (list.Count))
                {
                    str += "<li data-target=\"#myCarousel\" data-slide-to=\"" + i + "\" class=\"active\"></li>";
                }
                else
                {
                    str += "<li data-target=\"#myCarousel\" data-slide-to=\"" + i + "\"></li>";
                }
            }
            str += "</ol><div class=\"carousel-inner\" role=\"listbox\">";

            for (int i = list.Count - 1; i >= 0; i--)
            {
                if (i == (list.Count - 1))
                {
                    str += "<div class=\"item active\"><a href=\"" + list[i].Link + "\"><img src=\"" + list[i].Picture + "\">";
                    str += "<div class=\"carousel-caption\">" + list[i].Name + "</div></a></div>";
                }
                else
                {
                    str += "<div class=\"item\"><a href=\"" + list[i].Link + "\"><img src=\"" + list[i].Picture + "\">";
                    str += "<div class=\"carousel-caption\">" + list[i].Name + "</div></a></div>";
                }
            }
            str += "</div>";
            ViewBag.MainSlide = str;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion

        #region[Services]
        public ActionResult _Services()
        {
            string str = "";
            var cat = db.Menus.Where(m => m.Active == true && m.Name=="Dịch vụ").FirstOrDefault();
            string levelm = cat.Level;
            var catsub = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == levelm && m.Active == true).OrderBy(m => m.Ord).ToList();
            var list = db.Images.Where(l => l.Position == 4 && l.Active == true).Take(4).ToList();
            str+="<div class=\"row heading\"><div class=\"col-4\"></div><div class=\"col-4 service-home\"><div class=\"box-wrapper home-box\"><h3 class=\"box-title\"><a href=\""+cat.Link+"\"><span>Dịch vụ của chúng tôi: </span></a></h3></div></div></div>";
            str += "<div class=\"row service-wrapper\"><div class=\"col-2\"></div>";
            for (int i = 0; i < catsub.Count;i++ )
            {
                str += "<div class=\"col-2 service-home\"><div class=\"box-wrapper home-box\">";
                str += "<h3 class=\"box-title\"><a href=\"" + catsub[i].Link + "\">" + catsub[i].Name + "</a></h3><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" />";
                str += "<p>" +list[i].Description + "</p><a class=\"button select-service\" role=\"button\" href=\""+catsub[i].Link+"\">CHỌN DỊCH VỤ</a></div></div>";
            }
            str += "<div class=\"col-2\"></div></div>";

            ViewBag.MainService = str;
                return PartialView();
        }
        #endregion

        #region[Home News]
        public ActionResult _HomeNews()
        {
            string str = "";
            var g1 = db.GroupNews.Where(m => m.Active == true && m.Name == "Khuyến mãi").SingleOrDefault();
            var g2 = db.GroupNews.Where(m => m.Active == true && m.Name == "Mẹo vặt gia đình").SingleOrDefault();
            var g3 = db.GroupNews.Where(m => m.Active == true && m.Name == "Sức khỏe gia đình").SingleOrDefault();
            var g4 = db.GroupNews.Where(m => m.Active == true && m.Name == "Góc nội trợ").SingleOrDefault();
            var g5 = db.GroupNews.Where(m => m.Active == true && m.Name == "Câu chuyện cuộc sống").SingleOrDefault();
            int g1Id = g1.Id;
            int g2Id = g2.Id;
            int g3Id = g3.Id;
            int g4Id = g4.Id;
            int g5Id = g5.Id;

            var list = db.News.Where(m => m.Active == true && m.Index == true).OrderByDescending(m => m.SDate).Take(3).ToList();
            for(int i=0;i<list.Count;i++)
            {
                if (i == 0)
                {
                    if (list[i].IdGroup == g1Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/khuyen-mai/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\">" + list[i].Content + "<br />" + list[i].Detail + "</div></div></div>"; }
                    else if (list[i].IdGroup == g2Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/meo-vat/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\">" + list[i].Content + "<br />" + list[i].Detail + "</div></div></div>"; }
                    else if (list[i].IdGroup == g3Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/suc-khoe/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\">" + list[i].Content + "<br />" + list[i].Detail + "</div></div></div>"; }
                    else if (list[i].IdGroup == g4Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/noi-tro/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\">" + list[i].Content + "<br />" + list[i].Detail + "</div></div></div>"; }
                    else if (list[i].IdGroup == g5Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/cuoc-song/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\">" + list[i].Content + "<br />" + list[i].Detail + "</div></div></div>"; }
                }
                else
                {
                    if (list[i].IdGroup == g1Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/khuyen-mai/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\"><p>" + list[i].Content + "</p></div><a href=\"/khuyen-mai/" + list[i].Tag + "\"><span class=\"news-detail\">Xem chi tiết</span></a></div></div>"; }
                    else if (list[i].IdGroup == g2Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/meo-vat/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\"><p>" + list[i].Content + "</p></div><a href=\"/meo-vat/" + list[i].Tag + "\"><span class=\"news-detail\">Xem chi tiết</span></a></div></div>"; }
                    else if (list[i].IdGroup == g3Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/suc-khoe/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\"><p>" + list[i].Content + "</p></div><a href=\"/suc-khoe/" + list[i].Tag + "\"><span class=\"news-detail\">Xem chi tiết</span></a></div></div>"; }
                    else if (list[i].IdGroup == g4Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/noi-tro/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\"><p>" + list[i].Content + "</p></div><a href=\"/noi-tro/" + list[i].Tag + "\"><span class=\"news-detail\">Xem chi tiết</span></a></div></div>"; }
                    else if (list[i].IdGroup == g5Id) { str += "<div class=\"box-wrapper main-box box\"><h3 class=\"box-title\"><a href=\"/cuoc-song/" + list[i].Tag + "\"><span>" + list[i].Name + "</span></a></h3>"; str += "<div class=\"box-detail\"><div class=\"box-thumbnail\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\" /></div><div class=\"box-content\"><p>" + list[i].Content + "</p></div><a href=\"/cuoc-song/" + list[i].Tag + "\"><span class=\"news-detail\">Xem chi tiết</span></a></div></div>"; }
                }
            }
            ViewBag.HomeNews = str;
            return PartialView();
        }

        #endregion

        #region[Latest News]
        public ActionResult _LatestNews()
        {
            string str = "";
            var g1 = db.GroupNews.Where(m => m.Active == true && m.Name == "Khuyến mãi").SingleOrDefault();
            var g2 = db.GroupNews.Where(m => m.Active == true && m.Name == "Mẹo vặt gia đình").SingleOrDefault();
            var g3 = db.GroupNews.Where(m => m.Active == true && m.Name == "Sức khỏe gia đình").SingleOrDefault();
            var g4 = db.GroupNews.Where(m => m.Active == true && m.Name == "Góc nội trợ").SingleOrDefault();
            var g5 = db.GroupNews.Where(m => m.Active == true && m.Name == "Câu chuyện cuộc sống").SingleOrDefault();
            var g6 = db.GroupNews.Where(m => m.Active == true && m.Name == "Bản tin Palmy").SingleOrDefault();
            int g1Id = g1.Id;
            int g2Id = g2.Id;
            int g3Id = g3.Id;
            int g4Id = g4.Id;
            int g5Id = g5.Id;
            int g6Id = g6.Id;
            var list = db.News.Where(m => m.Active == true).OrderByDescending(m => m.SDate).Take(15).ToList();
            //var list = db.News.Where(m => m.Active == true).OrderByDescending(m => m.SDate).Take(4).ToList();
            str += "<ul class=\"box-list news-feed\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdGroup == g1Id){str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/khuyen-mai/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">"+list[i].SDate+"</span>";}
                else if (list[i].IdGroup == g2Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/meo-vat/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g3Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/suc-khoe/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g4Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/noi-tro/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g5Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/cuoc-song/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g6Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/tin-tuc/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
            }
            str += "</ul>";
            //str += "</ul><a href=\"/\"><span class=\"news-detail\">Xem chi tiết</span></a>";
            ViewBag.LatestNews = str;
            return PartialView();
        }

        #endregion

        #region[Latest News]
        public ActionResult _LatestNews4()
        {
            string str = "";
            var g1 = db.GroupNews.Where(m => m.Active == true && m.Name == "Khuyến mãi").SingleOrDefault();
            var g2 = db.GroupNews.Where(m => m.Active == true && m.Name == "Mẹo vặt gia đình").SingleOrDefault();
            var g3 = db.GroupNews.Where(m => m.Active == true && m.Name == "Sức khỏe gia đình").SingleOrDefault();
            var g4 = db.GroupNews.Where(m => m.Active == true && m.Name == "Góc nội trợ").SingleOrDefault();
            var g5 = db.GroupNews.Where(m => m.Active == true && m.Name == "Câu chuyện cuộc sống").SingleOrDefault();
            var g6 = db.GroupNews.Where(m => m.Active == true && m.Name == "Bản tin Palmy").SingleOrDefault();
            int g1Id = g1.Id;
            int g2Id = g2.Id;
            int g3Id = g3.Id;
            int g4Id = g4.Id;
            int g5Id = g5.Id;
            int g6Id = g6.Id;
            var list = db.News.Where(m => m.Active == true).OrderByDescending(m => m.SDate).Take(4).ToList();
            //var list = db.News.Where(m => m.Active == true).OrderByDescending(m => m.SDate).Take(4).ToList();
            str += "<ul class=\"box-list news-feed\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IdGroup == g1Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/khuyen-mai/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g2Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/meo-vat/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g3Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/suc-khoe/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g4Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/noi-tro/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g5Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/cuoc-song/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
                else if (list[i].IdGroup == g6Id) { str += "<li class=\"last\"><span class=\"list_active\"></span><a href=\"/tin-tuc/" + list[i].Tag + "\" class=\"last\"><span>" + list[i].Name + "</span></a></li><span class=\"news-date\">" + list[i].SDate + "</span>"; }
            }
            str += "</ul>";
            //str += "</ul><a href=\"/\"><span class=\"news-detail\">Xem chi tiết</span></a>";
            ViewBag.LatestNews = str;
            return PartialView();
        }

        #endregion

        #region[Family Tips]
        public ActionResult _FamilyTips()
        {
            string chuoi = "";
            var gr = db.GroupNews.Where(m => m.Active == true && m.Name == "Mẹo vặt gia đình").FirstOrDefault();
            string g_name = gr.Name;
            string g_link = "/"+ gr.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == 3).OrderByDescending(p => p.Ord).Take(4).ToList();
            chuoi += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    chuoi += "<li class=\"current\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" class=\"current\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    chuoi += "<li class=\"last\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" class=\"last\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            chuoi += "</ul>";
            //for (int i = 0; i < list.Count; i++)
            //{
            //    chuoi += "<li><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\"/></a><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><p>" + list[i].Name + "</p></a></li>";
            //}
            ViewBag.GroupName = g_name;
            ViewBag.GroupLink = g_link;
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion

        #region[Health]
        public ActionResult _Health()
        {
            string chuoi = "";
            var gr = db.GroupNews.Where(m => m.Active == true && m.Name == "Sức khỏe gia đình").FirstOrDefault();
            string g_name = gr.Name;
            string g_link = "/" + gr.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == 4).OrderByDescending(p => p.Ord).Take(4).ToList();
            chuoi += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    chuoi += "<li class=\"current\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/suc-khoe/" + list[i].Tag + "\" class=\"current\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    chuoi += "<li class=\"last\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/suc-khoe/" + list[i].Tag + "\" class=\"last\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            chuoi += "</ul>";
            //for (int i = 0; i < list.Count; i++)
            //{
            //    chuoi += "<li><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\"/></a><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><p>" + list[i].Name + "</p></a></li>";
            //}
            ViewBag.GroupName = g_name;
            ViewBag.GroupLink = g_link;
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion

        #region[HomeMaker]
        public ActionResult _HomeMaker()
        {
            string chuoi = "";
            var gr = db.GroupNews.Where(m => m.Active == true && m.Name == "Góc nội trợ").FirstOrDefault();
            string g_name = gr.Name;
            string g_link = "/" + gr.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == 5).OrderByDescending(p => p.Ord).Take(4).ToList();
            chuoi += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    chuoi += "<li class=\"current\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/noi-tro/" + list[i].Tag + "\" class=\"current\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    chuoi += "<li class=\"last\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/noi-tro/" + list[i].Tag + "\" class=\"last\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            chuoi += "</ul>";
            //for (int i = 0; i < list.Count; i++)
            //{
            //    chuoi += "<li><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\"/></a><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><p>" + list[i].Name + "</p></a></li>";
            //}
            ViewBag.GroupName = g_name;
            ViewBag.GroupLink = g_link;
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion

        #region[Life Story]
        public ActionResult _LifeStory()
        {
            string chuoi = "";
            var gr = db.GroupNews.Where(m => m.Active == true && m.Name == "Câu chuyện cuộc sống").FirstOrDefault();
            string g_name = gr.Name;
            string g_link = "/" + gr.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == 6).OrderByDescending(p => p.Ord).Take(4).ToList();
            chuoi += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    chuoi += "<li class=\"current\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/cuoc-song/" + list[i].Tag + "\" class=\"current\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    chuoi += "<li class=\"last\"><span class=\"list_active\"></span>";
                    chuoi += "<a href=\"/cam-nang/cuoc-song/" + list[i].Tag + "\" class=\"last\">";
                    chuoi += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            chuoi += "</ul>";
            //for (int i = 0; i < list.Count; i++)
            //{
            //    chuoi += "<li><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\"/></a><a href=\"/cam-nang/meo-vat/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><p>" + list[i].Name + "</p></a></li>";
            //}
            ViewBag.GroupName = g_name;
            ViewBag.GroupLink = g_link;
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion

        #region[Side bar]


        #region[Tips Home]
        public ActionResult _Tips20()
        {
            var cat = db.GroupNews.Where(m => m.Active == true && m.Name == "Kiến thức vệ sinh").SingleOrDefault();
            int catId = cat.Id;
            string cat_name = cat.Name;
            string cat_link = "/" + cat.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == catId).OrderByDescending(m => m.Ord).Take(20).ToList();
            string tips = "";
            tips += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    tips += "<li class=\"current\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"current\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    tips += "<li class=\"last\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"last\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            tips += "</ul>";
            ViewBag.MenuList = tips;
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            return PartialView();
        }
        public ActionResult _Tips10()
        {
            var cat = db.GroupNews.Where(m => m.Active == true && m.Name == "Kiến thức vệ sinh").SingleOrDefault();
            int catId = cat.Id;
            string cat_name = cat.Name;
            string cat_link = "/" + cat.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == catId).OrderByDescending(m => m.Ord).Take(10).ToList();
            string tips = "";
            tips += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    tips += "<li class=\"current\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"current\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    tips += "<li class=\"last\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"last\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            tips += "</ul>";
            ViewBag.MenuList = tips;
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            return PartialView();
        }
        public ActionResult _Tips5()
        {
            var cat = db.GroupNews.Where(m => m.Active == true && m.Name == "Kiến thức vệ sinh").SingleOrDefault();
            int catId = cat.Id;
            string cat_name = cat.Name;
            string cat_link = "/" + cat.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == catId).OrderByDescending(m => m.Ord).Take(5).ToList();
            string tips = "";
            tips += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    tips += "<li class=\"current\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"current\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    tips += "<li class=\"last\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/kien-thuc/" + list[i].Tag + "\" class=\"last\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            tips += "</ul>";
            ViewBag.MenuList = tips;
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            return PartialView();
        }

        #endregion

        #region[Services List]
        public ActionResult _ServicesList()
        {
            var menu = db.Menus.Where(m => m.Active == true && m.Name == "Dịch vụ").SingleOrDefault();
            string cat_name = menu.Name;
            string cat_link = menu.Link;
            string root_menu_lvl = menu.Level.Substring(0, 5);
            var list = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == root_menu_lvl && m.Active == true).OrderBy(m => m.Ord).ToList();
            string str = "";
            str += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    str += "<li class=\"current\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"current\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    str += "<li class=\"last\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"last\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            str += "</ul>";
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            ViewBag.MenuList = str;
            return PartialView();

        }
        #endregion

        #region[About List]
        public ActionResult _AboutList()
        {
            var menu = db.Menus.Where(m => m.Active == true && m.Name == "Giới thiệu").SingleOrDefault();
            string root_menu_lvl = menu.Level.Substring(0, 5);
            var list = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == root_menu_lvl && m.Active == true).OrderBy(m => m.Ord).ToList();
            string str = "";
            str += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    str += "<li class=\"current\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"current\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    str += "<li class=\"last\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"last\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            str += "</ul>";
            ViewBag.MenuList = str;
            return PartialView();

        }
        #endregion

        #region[Promotion List]
        public ActionResult _PromotionList()
        {
            var cat = db.GroupNews.Where(m => m.Active == true && m.Name == "Khuyến mại").SingleOrDefault();
            int catId = cat.Id;
            string cat_name = cat.Name;
            string cat_link = "/" + cat.Tag;
            var list = db.News.Where(m => m.Active == true && m.IdGroup == catId).OrderByDescending(m => m.Ord).Take(5).ToList();
            string tips = "";
            tips += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    tips += "<li class=\"current\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/khuyen-mai/" + list[i].Tag + "\" class=\"current\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    tips += "<li class=\"last\"><span class=\"list_active\"></span>";
                    tips += "<a href=\"/khuyen-mai/" + list[i].Tag + "\" class=\"last\">";
                    tips += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            tips += "</ul>";
            ViewBag.MenuList = tips;
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            return PartialView();
        }

        #endregion


        #region[Recruitment List]
        public ActionResult _RecruitmentList()
        {
            var menu = db.Menus.Where(m => m.Active == true && m.Name == "Tuyển dụng").SingleOrDefault();
            string cat_name = menu.Name;
            string cat_link = menu.Link;
            string root_menu_lvl = menu.Level.Substring(0, 5);
            var list = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == root_menu_lvl).OrderBy(m => m.Ord).ToList();
            string str = "";
            str += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    str += "<li class=\"current\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"current\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    str += "<li class=\"last\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"last\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            str += "</ul>";
            ViewBag.CatName = cat_name;
            ViewBag.CatLink = cat_link;
            ViewBag.MenuList = str;
            return PartialView();

        }
        #endregion

        #region[Process List]
        public ActionResult _ProcessList()
        {
            var menu = db.Menus.Where(m => m.Active == true && m.Name == "Quy trình").SingleOrDefault();
            string root_menu_lvl = menu.Level.Substring(0, 5);
            var list = db.Menus.Where(m => m.Level.Length == 10 && m.Level.Substring(0, 5) == root_menu_lvl).OrderBy(m => m.Ord).ToList();
            string str = "";
            str += "<ul class=\"box-list\">";
            for (int i = 0; i < list.Count; i++)
            {
                if (Request.Url.ToString().IndexOf(list[i].Tag) > 0)
                {
                    str += "<li class=\"current\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"current\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
                else
                {
                    str += "<li class=\"last\"><span class=\"list_active\"></span>";
                    str += "<a href=\"" + list[i].Link + "\" class=\"last\">";
                    str += "<span>" + list[i].Name + "</span></a><div class=\"clear\"></div></li>";
                }
            }
            str += "</ul>";
            ViewBag.MenuList = str;
            return PartialView();

        }
        #endregion

        #endregion








        /*   left main  */
#region[Left Menu]
        public ActionResult _LeftMenu()
        {
            string chuoi = "";
            var list = db.Menus.Where(m => m.Active == true && m.Position==3).OrderBy(m => m.Ord).ToList();

            for (int i = 0; i < list.Count; i++)
            {
                chuoi += "<li><a href=\"/" + list[i].Tag + "\">" + list[i].Name + "</a>";
            }
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion  



#region[Video]
        public ActionResult _Video()
        {
            return PartialView();
        }
        #endregion

#region[Statistic]
        public ActionResult _Statistic()
        {
            return PartialView();
        }
        #endregion

/*   right main  */
#region[Promotion]
        public ActionResult _Promotion()
        {
            return PartialView();
        }
        #endregion     

#region[Cost List]
        public ActionResult _CostList()
        {
            return PartialView();
        }
        #endregion

#region[Staff Profile]
        public ActionResult _StaffProfile()
        {
            return PartialView();
        }
        #endregion



#region[Google Map]
        public ActionResult _GoogleMap()
        {
            return PartialView();
        }
        #endregion

#region[Sub Social Network]
        public ActionResult _SubSocial()
        {
            return PartialView();
        }
        #endregion

        #region[Top Footer]
        public ActionResult _TopFooter()
        {
            string chuoi = "";
            var list = db.Configs.Where(m => m.Id > 0).Take(1).ToList();
            if (list.Count > 0)
            {
                chuoi = list[0].Copyright;
            }
            ViewBag.View = chuoi;

            return PartialView();
        }
        #endregion

        #region[Center Footer]
        public ActionResult _CenterFooter()
        {

            return PartialView();
        }
        #endregion

        #region[Bottom Footer]
        public ActionResult _BottomFooter()
        {

            return PartialView();
        }
        #endregion     

//#region[_Footer]
//        public ActionResult _Footer()
//        {
//            string chuoi = "";
//            var list = db.Advertises.Where(m => m.Position == 7 && m.Active == true).Take(5).ToList();
//            for (int i = 0; i < list.Count; i++)
//            {
//                if (list[i].Image != null && list[i].Image != "")
//                {
//                    if (list[i].Image.IndexOf(".swf") > 0)
//                    {
//                        chuoi += "<object classid=\"clsid:D27CDB6E-AE6D-11cf-96B8-444553540000\" codebase=\"http://active.macromedia.com/ flash5/cabs/swflash.cab#version=5,0,0,0\" style=\"width: 700px; height: 291px\">";
//                        chuoi += "<param name=\"MOVIE\" value=\"" + list[i].Image + "\">";
//                        chuoi += "<param name=\"PLAY\" value=\"true\">";
//                        chuoi += "<param name=\"LOOP\" value=\"true\">";
//                        chuoi += "<param name=\"WMODE\" value=\"opaque\">";
//                        chuoi += "<param name=\"QUALITY\" value=\"high\">";
//                        chuoi += "<embed src=\"" + list[i].Image + "\" width=\"540px\" height=\"291px\" play=\"true\" loop=\"true\" wmode=\"opaque\" quality=\"high\" pluginspage=\"http://www.macromedia.com/shockwave/ download/index.cgi?P1_Prod_Version=ShockwaveFlash\">";
//                        chuoi += "</object>";
//                    }
//                    else
//                    {
//                        chuoi += "<a href=\"" + list[i].Link + "\" title=\"" + list[i].Name + "\" >";
//                        chuoi += "<img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\" />";
//                        chuoi += "</a>";
//                    }
//                }
//                else
//                {
//                    chuoi += list[i].Description;
//                }
//            }

//            ViewBag.View = chuoi;
            
           
//            return PartialView();
//        }
//        #endregion


/* reserve */

#region[Family HandBook]
        public ActionResult _FamilyHandBook()
        {
            string chuoi = "";
            var list = db.News.Where(m => m.Active == true && m.IdGroup == 12).OrderByDescending(p => p.Ord).Take(12).ToList();
            for (int i = 0; i < list.Count; i++)
            {
                chuoi += "<li><a href=\"/bai-viet/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Picture + "\" alt=\"" + list[i].Name + "\"/></a><a href=\"/bai-viet/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><p>" + list[i].Name + "</p></a></li>";
            }
            ViewBag.View = chuoi;
            list.Clear();
            list = null;
            return PartialView();
        }
        #endregion        

//#region[Autocomplete Product Name]
//        // Autocomplete for textbox search 
//        [HttpGet]
//        public ActionResult Autocomplete(string term)
//        {
//            var productNames = from p in db.Products
//                               select p.Name;
//            string[] items = productNames.ToArray();

//            var filteredItems = items.Where(
//                item => item.IndexOf(term, StringComparison.InvariantCultureIgnoreCase) >= 0
//                );
//            return Json(filteredItems, JsonRequestBehavior.AllowGet);
//        }
//        #endregion

//#region[Thống kê đơn hàng]
//        public ActionResult _ThongKeDonHang()
//        {   
//            var tong= db.Ords.ToList();
//            ViewBag.Tong = tong.Count();
//            ViewBag.Moi = tong.Where(o => o.Status == "1").Count();
//            ViewBag.Nhantien = tong.Where(o => o.Status == "2").Count();
//            ViewBag.Nhanguihang = tong.Where(o => o.Status == "3").Count();
//            ViewBag.Huy = tong.Where(o => o.Status == "4").Count();
//            return PartialView();
//        }
//        #endregion

//#region[Ảnh quảng cáo]
//        public ActionResult _AdvLeft()
//        {
//            string chuoi = "";
//            var list = db.Advertises.Where(m => m.Target == "1" && m.Active == true).OrderBy(a => a.Orders).Take(10).ToList();
//            for (int i = 0; i < list.Count; i++)
//            {
//                if (list[i].Image != null && list[i].Image != "")
//                {
//                    chuoi += "<a href=\"" + list[i].Link + "\" title=\"" + list[i].Name + "\" >";
//                    chuoi += "<img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\" />";
//                    chuoi += "</a>";
//                }
//                else
//                {
//                    chuoi += list[i].Description;
//                }
//            }
//            ViewBag.View = chuoi;
//            return PartialView();
//        }
//        #endregion

//#region[Đăng ký làm khách hàng]
//        public ActionResult _RegistryCustomer()
//        {
//            string chuoi = "";
//            var list = db.Advertises.Where(m => m.Active == true && m.Position == 9).Take(1).ToList();
//            chuoi += "<a href=\"" + list[0].Link + "\" title=\"" + list[0].Name + "\" >";
//            chuoi += "<img src=\"" + list[0].Image + "\" alt=\"" + list[0].Name + "\" />";
//            chuoi += "</a>";
//            ViewBag.View = chuoi;

//            return PartialView();
//        }
//        #endregion

//#region[Đăng ký làm nhân viên]
//        public ActionResult _RegistryEmployee()
//        {
//            string chuoi = "";
//            var list = db.Advertises.Where(m => m.Active == true && m.Position == 9).Take(1).ToList();
//            chuoi += "<a href=\"" + list[0].Link + "\" title=\"" + list[0].Name + "\" >";
//            chuoi += "<img src=\"" + list[0].Image + "\" alt=\"" + list[0].Name + "\" />";
//            chuoi += "</a>";
//            ViewBag.View = chuoi;

//            return PartialView();
//        }
//        #endregion

//#region[Menu gói dịch vụ]
//        public ActionResult _LeftProduct()
//        {
//            string chuoi = "";
//            var list = db.Products.Where(m => m.Active == true && m.Index == true).OrderByDescending(p => p.Id).Take(5).ToList();
//            for (int i = 0; i < list.Count; i++)
//            {
//                chuoi += "<li><a href=\"/thong-tin/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><span>" + list[i].Name + "</span></a></li>";

//            }
//            ViewBag.View = chuoi;
//            list.Clear();
//            list = null;
//            return PartialView();
//        }
//        #endregion

    }
}
