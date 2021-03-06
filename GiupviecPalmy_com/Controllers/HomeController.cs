﻿using System;
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
//using System.Web.Security;
//using System.Net.Mail;
//using System.Globalization;

namespace GiupviecPalmy_com.Controllers
{
    public class HomeController : Controller
    {
        giupviecpalmy_com_dbEntities data = new giupviecpalmy_com_dbEntities();

        public ActionResult Index()
        {
            #region[Title, Keyword, Deskription]
            try
            {
                var listconfig = (from p in data.Configs select p).ToList();
                if (listconfig.Count > 0) { ViewBag.tit = listconfig[0].Title; ViewBag.des = listconfig[0].Description; ViewBag.key = listconfig[0].Keyword; }
                listconfig.Clear();
                listconfig = null;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
            #endregion
           
            //list.Clear();
            //list = null;
            return View();
        }

        //public ActionResult Index(int? page, string ProName, string currentProName)
        //{
        //    if (Session["CurrentProName"] != null)
        //    {
        //        currentProName = Session["CurrentProName"].ToString();
        //        Session["CurrentProName"] = null;
        //    }
        //    var list = (from p in data.News where p.Active == true && p.IdGroup == 24 orderby p.Id descending select p).ToList();

        //    #region[Title, Keyword, Deskription]
        //    var listconfig = (from p in data.Configs select p).ToList();
        //    if (listconfig.Count > 0) { ViewBag.tit = listconfig[0].Title; ViewBag.des = listconfig[0].Description; ViewBag.key = listconfig[0].Keyword; }
        //    listconfig.Clear();
        //    listconfig = null;
        //    #endregion
        //    if (!String.IsNullOrEmpty(ProName))
        //    {
        //        list = list.Where(p => p.Name.ToUpper().Contains(ProName.ToUpper())).OrderByDescending(p => p.Id).ToList();
        //    }
        //    list = list.OrderByDescending(p => p.Id).ToList();         
        //    //list.Clear();
        //    //list = null;
        //    return View(list);
        //}
        //public ActionResult Detail(string tag)
        //{
        //    string chuoi = "";
        //    string chuoilink = "";
        //    string image = "";
        //    string imagethumb = "";
        //    string Cart = "";
        //    int category = 0;
        //    int proId=0;
        //    string baohanh = "";
        //    string noibat = "";
        //    string chitiet = "";
        //    string thanhtoan = "";
        //    string canhbao = "";
        //    string fb = "";
        //    var pro = (from p in data.Products where p.Tag == tag select p).ToList();
        //    if (pro.Count > 0)
        //    {
        //        proId = pro[0].Id;
        //        category = pro[0].IdCategory;
        //        //var cate = (from p in data.GroupProducts where p.Id == category select p).ToList();
        //        //if (cate.Count > 0)
        //        //{
        //        //    chuoilink = "<li class='Last'><a href='/danh-muc/" + cate[0].Tag + "'>" + cate[0].Name + "</a></li>";
        //        //}
        //        chuoilink = "<li class='Last'><a href='/nhan-vien'>Hồ sơ nhân viên</a></li>";
        //        //cate.Clear();
        //        //cate = null;
        //        ViewBag.link = chuoilink;
        //        int g = 0;
        //        if (pro[0].Num != null) { g = int.Parse(pro[0].Num.ToString()); }
        //        chuoi += "<input type=\"hidden\" id=\"item_id\" value=\""+ pro[0].Id +"\">";
        //        imagethumb += "<li class='active' rel='1'><img src=\"" + pro[0].Image + "\" alt=\"" + pro[0].Name + "\" title=\"Click to enlarge\" /></li>";
        //        image += "<a href=\"" + pro[0].Image + "\" class=\"highslide\" rel=\"position: 'inside' , showTitle: false\" id=\"zoom1\" style=\"position: relative; display: block;\" onclick=\"return hs.expand(this)\"><img src=\"" + pro[0].Image + "\" alt=\"" + pro[0].Name + "\" /></a>";
        //        chuoi += "<input type=\"hidden\" id=\"item_id\" value=\""+ pro[0].Id +"\" />";
        //        chuoi +="<p id=\"titPro\">"+ pro[0].Name +"</p>";
        //        if(pro[0].Code!=null && pro[0].Code != "")
        //        {
        //            chuoi +="<p>Mã dịch vụ: <span class=\"value\">"+ pro[0].Code +"</span></p>";
        //        }
        //        chuoi += "<div class=\"divInfo\">";
        //        //if ((pro[0].PricePromotion / pro[0].PriceRetail) * 100 < 100)
        //        //{
        //        //    chuoi += "<p><span id=\"valBanle-cu\">Giá cũ: " + StringClass.Format_Price(pro[0].PriceRetail.ToString()) + "đ</span></p>";
        //        //    chuoi += "<p>Giá bán: <span id=\"valBanle\"> " + StringClass.Format_Price(pro[0].PricePromotion.ToString()) + "đ</span></p>";
        //        //}
        //        //else
        //        //{
        //        //    chuoi += "<p>Giá: <span id=\"valBanle\"> " + StringClass.Format_Price(pro[0].PricePromotion.ToString()) + "đ</span></p>";
        //        //}
        //        chuoi += "<span class=\"lblProduct\">&nbsp;</span>";
        //        chuoi += "</div>";
        //        int pid=pro[0].Id;
        //        var proimages = (from im in data.ProImages where im.IdPro == pid select im).ToList();
        //        int k = 2;
        //        for(int j = 0; j<proimages.Count;j++)
        //        {
        //            if (proimages.Count > 1)
        //            {
        //                imagethumb += "<li class='active' rel='" + (k + j) + "'><img src=\"" + proimages[j].Image + "\" alt=\"" + pro[0].Name + "\" /></li>";
        //            }
        //            image += "<a href=\"" + proimages[j].Image + "\" class=\"highslide\" onclick=\"return hs.expand(this)\"><img src=\"" + proimages[j].Image + "\" alt=\"" + pro[0].Name + "\" /></a>";
        //        }
        //        //Cart += "<p id=\"Cart\"><a id=\"btnAddCart\" title=\"Mua ngay\" href=\"javascript:;\" class=\"btnAddCart\" rel=\"/Home/checkout\"><span id=\"txt1\">Mua ngay</span></a></p>";
        //        //Cart += "<p id=\"Cart\"><a id=\"btnAddCart\" href=\"javascript:;\" class=\"btnBuyNow add-to-cart\" title=\"Thêm sản phẩm này vào giỏ hàng\"><span id=\"txt\"></span></a><a id=\"btnAddCart\" title=\"Mua ngay\" href=\"javascript:;\" class=\"btnAddCart\" rel=\"/Home/checkout\"><span id=\"txt1\">Mua ngay</span></a></p>";
        //        chitiet = pro[0].Content;
        //        noibat = pro[0].Noibat;
        //        baohanh = pro[0].Baohanh;
        //        #region[Title, Keyword, Deskription]
        //        string t = pro[0].Title;
        //        string tt = pro[0].Description;
        //        string ttt = pro[0].Keyword;
        //        if (pro[0].Title != null && pro[0].Title.Length > 0) { ViewBag.tit = pro[0].Title; } else { ViewBag.tit = pro[0].Name; }
        //        if (pro[0].Description != null && pro[0].Description.Length > 0) { ViewBag.des = pro[0].Description; } else { ViewBag.des = pro[0].Name; }
        //        if (pro[0].Keyword != null && pro[0].Keyword.Length > 0) { ViewBag.key = pro[0].Keyword; } else { ViewBag.key = pro[0].Name; }
        //        #endregion
        //        ViewBag.cart = Cart;
        //        proimages.Clear();
        //        proimages = null;

        //        fb += "<div class=\"fb-like\" style=\"margin: 0;padding:0;\" data-href=\"" + Request.Url.ToString() + "\" data-send=\"true\" data-width=\"538\" data-show-faces=\"true\"></div>";
        //        fb += "<div class=\"fb-comments\" style=\"margin: 0;padding:0;\" data-href=\"" + Request.Url.ToString() + "\" data-width=\"538\" data-num-posts=\"5\"></div>";
                
        //        #region[Sản phẩm cùng loại]
        //        string chuoicungloai = "";
        //        var list = (from p in data.Products where p.Active == true && p.IdCategory == category && p.Tag!=tag orderby p.Id descending select p).Take(21).ToList();
        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            if (i % 3 != 0)
        //            {
        //                chuoicungloai += "<li>";
        //            }
        //            else
        //            {
        //                chuoicungloai += "<li class=\"right\">";
        //            }
        //            chuoicungloai += "<div class=\"imagespro\"><a href=\"/thong-tin/" + list[i].Tag + "\" title=\"" + list[i].Name + "\"><img src=\"" + list[i].Image + "\" alt=\"" + list[i].Name + "\" /></a></div>";
        //            chuoicungloai += "<div>";
        //            chuoicungloai += "<p class=\"sp_code\"><a href=\"/thong-tin/" + list[i].Tag + "\">" + list[i].Name + "</a></p>";
        //            if (list[i].PricePromotion == 0)
        //            {
        //                chuoicungloai += "<p class=\"gia_sp\">Giá: Vui lòng liên hệ</p>";
        //            }
        //            else
        //            {
        //                chuoicungloai += "<p class=\"gia_sp\">Giá bán: " + os.os.Format_Price(list[i].PricePromotion.ToString()) + " đ</p>";
        //            }
        //            chuoicungloai += "<p class=\"detailpro\"><a href=\"/thong-tin/" + list[i].Tag +"\">Chi tiết</a></p>";
        //            chuoicungloai += "</div>";
        //            chuoicungloai += "</li>";
        //        }
        //        ViewBag.cungloai = chuoicungloai;
        //        list.Clear();
        //        list = null;
        //        #endregion
        //        //#region[Sản phẩm nhiều người mua]
        //        //string chuoinhieu = "";
        //        //var listnn = (from p in data.v_Top5Order select p).ToList();
        //        //for (int e = 0; e < listnn.Count; e++)
        //        //{
        //        //    chuoinhieu +="<li>";
        //        //    chuoinhieu +="<a href=\"/dong-ho/"+ listnn[e].Tag +"\"><img src=\""+ listnn[e].Image +"\" /></a>";
        //        //    chuoinhieu += "<a href=\"/dong-ho/" + listnn[e].Tag + "\">"+ listnn[e].Name +"</a>";
        //        //    if ((listnn[e].PricePromotion / listnn[e].PriceRetail) * 100 < 100)
        //        //    {
        //        //        chuoinhieu += "<p><span>" + os.os.Format_Price(listnn[e].PriceRetail.ToString()) + "đ</span></p>";
        //        //        chuoinhieu += "<p>" + os.os.Format_Price(listnn[e].PricePromotion.ToString()) + "đ</p>";
        //        //    }
        //        //    else
        //        //    {
        //        //        chuoinhieu += "<p>" + os.os.Format_Price(listnn[e].PricePromotion.ToString()) + "đ</p>";
        //        //    }
        //        //    chuoinhieu += "</li>";
        //        //}
        //        //ViewBag.nhieu = chuoinhieu;
        //        //listnn.Clear();
        //        //listnn = null;
        //        //#endregion
        //    }
        //    ViewBag.images = image;
        //    ViewBag.imagethumb = imagethumb;
        //    ViewBag.pro = chuoi;
        //    pro.Clear();
        //    pro = null;
        //    #region[Hiển thị thông tin các Tab]
        //    var listconf = data.Configs.ToList();
        //    if (listconf.Count > 0)
        //    {
        //        thanhtoan = listconf[0].Thanhtoan;
        //        canhbao = listconf[0].Canhbao;
        //    }
        //    listconf.Clear();
        //    listconf=null;
        //    string chuoitab_head = "";
        //    string chuoitab_content = "";
        //    if (chitiet != null && chitiet != "")
        //    {
        //        chuoitab_head += "<li><a href=\"#thong-tin-chi-tiet\">Thông tin</a></li>";
        //        chuoitab_content += "<div id=\"thong-tin-chi-tiet\"><p>"+ chitiet +"</p></div>";
        //    }
        //    if (noibat != null && noibat != "")
        //    {
        //        chuoitab_head += "<li><a href=\"#tabs-2\">Ưu điểm nổi bật</a></li>";
        //        chuoitab_content += "<div id=\"tabs-2\"><p>" + noibat + "</p></div>";
        //    }
        //    if (baohanh != null && baohanh != "")
        //    {
        //        chuoitab_head += "<li><a href=\"#tabs-3\">Thông tin bảo hành</a></li>";
        //        chuoitab_content += "<div id=\"tabs-3\"><p>" + baohanh + "</p></div>";
        //    }
        //    if (thanhtoan != null && thanhtoan != "")
        //    {
        //        chuoitab_head += "<li><a href=\"#tabs-4\">Phương thức thanh toán</a></li>";
        //        chuoitab_content += "<div id=\"tabs-4\"><p>" + thanhtoan + "</p></div>";
        //    }
        //    if (canhbao != null && canhbao != "")
        //    {
        //        chuoitab_head += "<li><a href=\"#tabs-5\">Cảnh báo</a></li>";
        //        chuoitab_content += "<div id=\"tabs-5\"><p>" + canhbao + "</p></div>";
        //    }
        //    chuoitab_head += "<li><a href=\"#binh-luan\">Bình luận</a></li>";
        //    chuoitab_content += "<div class=\"binh-luan\"><p>" + fb + "</p></div>";
        //    ViewBag.tabhead = chuoitab_head;
        //    ViewBag.tabcontent = chuoitab_content;
        //    #endregion
        //    #region[Hỗ trợ trực tuyến]
        //    string chuoisp = "";
        //    //string chuoi_hotline = "";
        //    //string chuoi_hotline = "";
        //    //string chuoi_mobile = "";
        //    var listsp = data.Supports.ToList();
        //    if (listsp.Count > 0)
        //    {
        //        for (int i = 0; i < listsp.Count; i++)
        //        {
        //            //chuoisp += listsp[i].Name;
        //            //chuoisp += "<p><a href=\"ymsgr:sendim?" + listsp[i].NickYahoo + "\" title=\"" + listsp[i].Name + "\"><img alt=\"" + listsp[i].Name + "\" src=\"http://mail.opi.yahoo.com/online?u=" + listsp[i].NickYahoo + "&amp;m=g&amp;t=1\" border=\"0\" align=\"middle\"></a></p>";
        //            //chuoisp += "<p><a href=\"skype:" + listsp[i].NickSkype + "?chat\"><img src=\"/Content/Images/Skype.png\" title=\"" + listsp[i].Name + "\"></a></p>";
        //            chuoisp += "<p><a href=\"#\" class=\"hl\" title=\"" + listsp[i].Name + "\"></a><span>HOTLINE: " + listsp[i].Hotline + "</span></p>";
        //            //if (listsp[i].Type == 0)
        //            //{
        //            //    chuoisp += "<p><a href=\"ymsgr:sendim?" + listsp[i].Nick + "\" title=\"" + listsp[i].Name + "\"><img alt=\"" + listsp[i].Name + "\" src=\"http://opi.yahoo.com/online?u=" + listsp[i].Nick + "&amp;m=g&amp;t=1\" border=\"0\" align=\"middle\"></a></p>";
        //            //}
        //            //else if (listsp[i].Type == 1)
        //            //{
        //            //    chuoisp += "<p><a href=\"skype:" + listsp[i].Nick + "?chat\"><img src=\"HTTP://MYSTATUS.SKYPE.COM/smallclassic/" + listsp[i].Nick + "\" title=\"" + listsp[i].Name + "\"></a></p>";
        //            //}
        //            //else 
        //            //    if (listsp[i].Type == 2)
        //            //    {
        //            //        chuoi_hotline += "<p><a href=\"#\" class=\"hl\" title=\"" + listsp[i].Name + "\"></a><span>HOTLINE: " + listsp[i].Tel + "</span></p>";
        //            //    }
        //            //    else if (listsp[i].Type == 3)
        //            //    {
        //            //        chuoi_tel += "<p><a href=\"#\" class=\"cel\" title=\"" + listsp[i].Name + "\"></a>" + listsp[i].Tel + "</p>";
        //            //    }
        //            //    else if (listsp[i].Type == 4)
        //            //    {
        //            //        chuoi_mobile += "<p><a href=\"#\" class=\"mob\" title=\"" + listsp[i].Name + "\"></a>" + listsp[i].Tel + "</p>";
        //            //    }
        //            //}
        //            //chuoisp = chuoisp + chuoi_tel + chuoi_mobile + chuoi_hotline;
        //        }
        //    }
        //    ViewBag.support = chuoisp;
           
        //    #endregion
        //    return View();
                
        //    }
        
        //#region[Index su dung PagedList]
        //public ActionResult Index(int? page, string tag)
        //{
        //    if (Request.HttpMethod == "GET")
        //    {
        //    }
        //    else
        //    {
        //        page = 1;
        //    }

        //    #region[Phân trang]
        //    int pageSize = 15;
        //    int pageNumber = (page ?? 1);

        //    // Thiết lập phân trang
        //    PagedListRenderOptions ship = new PagedListRenderOptions();

        //    ship.DisplayLinkToFirstPage = PagedListDisplayMode.Always;
        //    ship.DisplayLinkToLastPage = PagedListDisplayMode.Always;
        //    ship.DisplayLinkToPreviousPage = PagedListDisplayMode.Always;
        //    ship.DisplayLinkToNextPage = PagedListDisplayMode.Always;
        //    ship.DisplayLinkToIndividualPages = true;
        //    ship.DisplayPageCountAndCurrentLocation = false;
        //    ship.MaximumPageNumbersToDisplay = 5;
        //    ship.DisplayEllipsesWhenNotShowingAllPageNumbers = true;
        //    ship.EllipsesFormat = "&#8230;";
        //    ship.LinkToFirstPageFormat = "Trang đầu";
        //    ship.LinkToPreviousPageFormat = "«";
        //    ship.LinkToIndividualPageFormat = "{0}";
        //    ship.LinkToNextPageFormat = "»";
        //    ship.LinkToLastPageFormat = "Trang cuối";
        //    ship.PageCountAndCurrentLocationFormat = "Page {0} of {1}.";
        //    ship.ItemSliceAndTotalFormat = "Showing items {0} through {1} of {2}.";
        //    ship.FunctionToDisplayEachPageNumber = null;
        //    ship.ClassToApplyToFirstListItemInPager = null;
        //    ship.ClassToApplyToLastListItemInPager = null;
        //    ship.ContainerDivClasses = new[] { "pagination-container" };
        //    ship.UlElementClasses = new[] { "pagination" };
        //    ship.LiElementClasses = Enumerable.Empty<string>();

        //    ViewBag.ship = ship;
        //    #endregion
        //    var g = data.GroupNews.Where(m => m.Id == 24).SingleOrDefault();
        //    if (g != null)
        //    {
        //        ViewBag.link = "<li class='Last'><span>" + g.Name + "</span></li>";
        //        var list = (from n in data.News where n.Active == true && n.IdGroup == 24 orderby n.Id descending select n).ToList();
        //        return View(list.ToPagedList(pageNumber, pageSize));
        //        list.Clear();
        //        list = null;
        //        //#region[Title, Keyword, Deskription]
        //        //if (g.Title.Length > 0) { ViewBag.tit = g.Title; } else { ViewBag.tit = g.Name; }
        //        //if (g.Description.Length > 0) { ViewBag.des = g.Description; } else { ViewBag.des = g.Name; }
        //        //if (g.Keyword.Length > 0) { ViewBag.key = g.Keyword; } else { ViewBag.key = g.Name; }
        //        //#endregion
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
        //#endregion


        
        //#region[Gio hang]
        //public ActionResult checkout()
        //{
        //    if (Session["ShoppingCart"] != null)
        //    {
        //        var cart = (ShoppingCartViewModel)Session["ShoppingCart"];
        //        return View(cart);
        //    }
        //    else
        //    {
        //        return Redirect("/");
        //    }
        //}
        //#endregion
        //#region[Gio hang]
        //public ActionResult BuyNow()
        //{
        //    if (Session["ShoppingCart"] != null)
        //    {
        //        var cart = (ShoppingCartViewModel)Session["ShoppingCart"];
        //        return View(cart);
        //    }
        //    else
        //    {
        //        return Redirect("/");
        //    }
        //}
        //#endregion
        //[HttpPost]
        //public ActionResult BuyNow(string Name, string Email, string Phone, string Address)
        //{
        //    //string chuoi = "";
        //    if (Session["ShoppingCart"] != null)
        //    {
        //        Customer mem = new Customer();
        //        Province provi = new Province();
        //        if (Name != "" && Email != "" && Phone != "" && Address!="")
        //        {
        //            #region[Lưu vào dababase theo tình huống có địa chỉ giao hàng là Địa chỉ mới]
        //            int provid = 0;
        //            float tongdiem = 0;
        //            float tongtien = 0;
        //            float diem = 0;
        //            float tien = 0;
        //            int w = 0;
        //            int ship = 0;
        //            int tienship = 0;
        //            string sTypePay = "";
        //            string email = Email;
        //            #region[Lưu vào bảng khách hàng]
        //            //GiupviecPalmy_com.Models.Customer customer = new GiupviecPalmy_com.Models.Customer();
        //            //customer.Name = Name;
        //            //customer.Email = Email;
        //            //customer.Password = Email;
        //            //customer.Address = Address;
        //            //customer.Tel = Phone;
        //            //customer.SDate = DateTime.Now;
        //            //customer.Status = false;
        //            //customer.P_xa = Address;
        //            //customer.Provice = 0;
        //            //customer.Diem = 0;
        //            //customer.Si = false;
        //            //customer.Vip = 0;
        //            //customer.Avarta = "";
        //            //customer.cPriceNT = 0;
        //            //customer.cNongthon = 0;
        //            data.sp_Customer_Insert(Name, Email, Email, Phone, Address, DateTime.Now, false, Address, 0, 0, false, 0, "", 0, 0);
        //            //data.Entry(mem).State = EntityState.Modified;
        //            data.SaveChanges();
        //            #endregion
        //            mem = data.Customers.Where(m => m.Email == email).FirstOrDefault();
        //            if (mem != null)
        //            {
        //                provid = 0;
        //                tongdiem = float.Parse(mem.Diem.ToString());
        //                var cart = (ShoppingCartViewModel)Session["ShoppingCart"];
        //                ShoppingCartViewModel shoppCart = (ShoppingCartViewModel)Session["ShoppingCart"];
        //                #region[Lưu dữ liệu vào bảng đơn hàng]
        //                GiupviecPalmy_com.Models.Ord ord = new GiupviecPalmy_com.Models.Ord();
        //                ord.IdCus = mem.Id;
        //                ord.Amount = shoppCart.CartTotal;
        //                ord.SDate = DateTime.Now;
        //                ord.TypePay = sTypePay;
        //                ord.Status = "1";
        //                ord.PriceVC = 0;
        //                ord.Name = Name;
        //                ord.Address = Address;
        //                ord.Tel = Phone;
        //                ord.ProviceId = provid;
        //                ord.Nongthon = 0;
        //                data.Ords.Add(ord);
        //                diem = shoppCart.CartTotal / 1000;
        //                tongdiem = tongdiem + diem;
        //                mem.Diem = tongdiem;
        //                data.Entry(mem).State = EntityState.Modified;
        //                data.SaveChanges();
        //                #endregion
        //                #region[Lưu vào bảng chi tiết đơn hàng]
        //                var listbillcus = data.Ords.OrderByDescending(m => m.Id).FirstOrDefault();
        //                foreach (var item in shoppCart.CartItems)
        //                {
        //                    var pro = data.Products.Where(m => m.Id == item.productId).FirstOrDefault();
        //                    OrderDetail billdetail = new OrderDetail();
        //                    billdetail.IdOr = listbillcus.Id;
        //                    billdetail.IdPro = item.productId;
        //                    billdetail.IdSize = item.idsize;
        //                    billdetail.IdColor = item.idcolor;
        //                    billdetail.Number = item.count;
        //                    w = (w + item.proweight * item.count);
        //                    //if (mem.Si == true)
        //                    //{
        //                        billdetail.Price = double.Parse(pro.PricePromotion.ToString());
        //                        tien = float.Parse(item.count.ToString()) * float.Parse(pro.PricePromotion.ToString());
        //                    //}
        //                    //else
        //                    //{
        //                    //    billdetail.Price = double.Parse(pro.PriceRetail.ToString());
        //                    //    tien = float.Parse(item.count.ToString()) * float.Parse(pro.PriceRetail.ToString());
        //                    //}
        //                    tongtien = tongtien + tien;
        //                    billdetail.Total = double.Parse(item.total.ToString());
        //                    //data.sp_OrderDetail_Insert();
        //                    data.OrderDetails.Add(billdetail);

        //                    pro.Num = pro.Num - int.Parse(item.count.ToString());

        //                    data.Entry(pro).State = EntityState.Modified;

        //                    data.SaveChanges();
        //                }
        //                #endregion
        //                #region[Update lại tổng tiền, tiền ship]
        //                tienship = ship;
        //                listbillcus.PriceNT = 0;
        //                listbillcus.PriceVC = tienship;
        //                listbillcus.Amount = tongtien + tienship;
        //                data.Entry(listbillcus).State = EntityState.Modified;
        //                data.SaveChanges();
        //                RemoveFromCartAll();
        //                #endregion
        //            }
        //            #endregion
        //            ShoppingCartViewModel shoppCarts = (ShoppingCartViewModel)Session["ShoppingCart"];
        //            for (int i = 0; i < shoppCarts.CartItems.Count; i++)
        //            {
        //                shoppCarts.CartItems.RemoveAt(i);
        //            }
        //            return RedirectToAction("order_success", "Pages");
        //        }
        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("/");
        //    }
        //}
        //int cartTotal;
        //public void RemoveFromCartAll()
        //{
        //    ShoppingCartViewModel shoppCart = (ShoppingCartViewModel)Session["ShoppingCart"];
        //    for (int i = 0; i < shoppCart.CartItems.Count; i++)
        //    {
        //        shoppCart.CartItems.RemoveAt(i);
        //    }
        //    if (shoppCart.CartItems.Count > 0)
        //    {
        //        for (int j = 0; j < shoppCart.CartItems.Count; j++)
        //        {
        //            cartTotal += shoppCart.CartItems[j].total;
        //        }
        //        shoppCart.CartTotal = cartTotal;
        //    }
        //    else
        //    {
        //        shoppCart.CartTotal = 0;
        //    }

        //    Session["ShoppingCart"] = shoppCart;
        //}
        //public ActionResult bando()
        //{
        //    return View();
        //}
     
    }
  
}